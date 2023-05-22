using ClosedXML.Excel;
using IkMeKursaDarbs.Data;
using IkMeKursaDarbs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkMeKursaDarbs
{
    public static class Utils
    {
        public static string ToSHA256(this string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(text);
                byte[] passwordHash = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(passwordHash).Replace("-", string.Empty).ToLower();
            }
        }
        public static void SelectOptionByRowField<TDataType>(this ComboBox comboBox, Expression<Func<TDataType, object>> expr, object columnValue) where TDataType : IdEntity
        {
            string columnName = GetMemberName(expr);
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var row = (comboBox.Items[i] as DataRowView).Row;
                if (row != null && row[columnName] == columnValue)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }
        public static string GetMemberName(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)expression;
                if (lambda.Body.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpr = (MemberExpression)lambda.Body;
                    return memberExpr.Member.Name;
                }
                else if (lambda.Body.NodeType == ExpressionType.Convert)
                {
                    var convertExpr = (UnaryExpression)lambda.Body;
                    if (convertExpr.Operand.NodeType == ExpressionType.MemberAccess)
                    {
                        var memberExpr = (MemberExpression)convertExpr.Operand;
                        return memberExpr.Member.Name;
                    }
                }
            }
            throw new ArgumentException("Invalid expression");
        }
        public static void SaveAsExcelReport(this List<MechanicTask> tasks, string reportName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Mechanic Tasks");
            worksheet.Range(1, 1, 10, 10).Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium);
            worksheet.Range(1, 1, 10, 10).Style.Border.SetInsideBorder(XLBorderStyleValues.Medium);
            worksheet.Range(1, 1, 1, 10).Merge();
            worksheet.Range(1, 1, 1, 10).SetValue(reportName);
            worksheet.Cell(2, 1).Value = "Name";
            worksheet.Cell(2, 2).Value = "Description";
            worksheet.Cell(2, 3).Value = "Completed";
            worksheet.Cell(2, 4).Value = "Created";
            worksheet.Cell(2, 5).Value = "Due";
            worksheet.Cell(2, 6).Value = "Parent Task";
            worksheet.Cell(2, 7).Value = "Assigned mechanic";
            worksheet.Cell(2, 8).Value = "Req. Specialization";
            worksheet.Cell(2, 9).Value = "Vehicle";
            worksheet.Cell(2, 10).Value = "VIN Number";
            var parentTasksIds = tasks.Where(t => t.ParentTaskId != -1).Select(t => t.ParentTaskId).ToHashSet();
            var mechSpecIds = tasks.Select(t => t.MechSpecId).ToHashSet();
            var parentTasks = Program.DbContext.DataSet.Query<MechanicTask>(mt => parentTasksIds.Contains(mt.Id));
            var mechSpecs = Program.DbContext.DataSet.Query<MechanicSpecialization>(ms => mechSpecIds.Contains(ms.Id));
            var mechanicIds = mechSpecs.Select(ms => ms.MechanicId).ToHashSet();
            var specIds = mechSpecs.Select(ms => ms.SpecializationId).ToHashSet();
            var mechanics = Program.DbContext.DataSet.Query<Mechanic>(m => mechanicIds.Contains(m.Id));
            var specs = Program.DbContext.DataSet.Query<Specialization>(s => specIds.Contains(s.Id));
            var vehicleIds = tasks.Select(v => v.VehicleId).ToHashSet();
            var vehicles = Program.DbContext.DataSet.Query<Vehicle>(v => vehicleIds.Contains(v.Id));

            for (int i = 0; i < tasks.Count; i++)
            {
                worksheet.Cell(i + 3, 1).Value = tasks[i].Name;
                worksheet.Cell(i + 3, 2).Value = tasks[i].Description;
                worksheet.Cell(i + 3, 3).Value = tasks[i].Completed ? "Yes" : "No";
                worksheet.Cell(i + 3, 4).Value = new DateTime(tasks[i].Created).ToString("MM/dd/yyyy");
                worksheet.Cell(i + 3, 5).Value = new DateTime(tasks[i].Due).ToString("MM/dd/yyyy");
                worksheet.Cell(i + 3, 6).Value = parentTasks.FirstOrDefault(t => t.Id == tasks[i].ParentTaskId)?.Name ?? string.Empty;
                var mechSpec = mechSpecs.FirstOrDefault(ms => ms.Id == tasks[i].MechSpecId);
                if (mechSpec != null)
                {
                    var mechanic = mechanics.FirstOrDefault(m => m.Id == mechSpec.MechanicId);
                    worksheet.Cell(i + 3, 7).Value = mechanic is null ? string.Empty : $"{mechanic.Name} {mechanic.Surname}";
                    worksheet.Cell(i + 3, 8).Value = specs.FirstOrDefault(s => s.Id == mechSpec.SpecializationId)?.Name ?? string.Empty;
                }
                var vehicle = vehicles.FirstOrDefault(v => v.Id == tasks[i].VehicleId);
                worksheet.Cell(i + 3, 9).Value = vehicle is null ? string.Empty : $"{vehicle.Brand} {vehicle.Model} {vehicle.VinNumber}";
                worksheet.Cell(i + 3, 10).Value = vehicle is null ? string.Empty : $"{vehicle.VinNumber}";
                worksheet.Columns().AdjustToContents();
                // Save to file
                workbook.SaveAs($"./Reports/{reportName}.xlsx");
            }
        }
    }
}
