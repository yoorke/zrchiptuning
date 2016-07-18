using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.IO;

namespace BRBuilder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        ArrayList arrTables;
        Dictionary<string, string> BEClasses = new Dictionary<string, string>();
        Dictionary<string, string> IRepositoryClasses = new Dictionary<string, string>();
        Dictionary<string, string> RepositoryClasses = new Dictionary<string, string>();
        Dictionary<string, string> BLClasses = new Dictionary<string, string>();

        string[] excludedColumns = new string[] {"id", "_insertDate", "_updateDate", "_userIDInsert", "_userIDUpdate", "_isActive"};

        private void openNewConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnect objfrmConnect = new frmConnect();
            objfrmConnect.ShowDialog();
        }

        private void loadDataForCurrentConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable SchemaTable;

                arrTables = new ArrayList();

                this.Refresh();

                if (Properties.Settings.Default.ConnString != string.Empty)
                {
                    using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                    {
                        try
                        {
                            conn.Open();
                            SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

                            for (int i = 0; i < SchemaTable.Rows.Count; i++)
                            {
                                arrTables.Add(SchemaTable.Rows[i].ItemArray[2].ToString());
                            }

                            lstTabels.Items.Clear();
                            lstTabels.Items.AddRange(arrTables.ToArray());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateClasses_Click(object sender, EventArgs e)
        {
            try
            {
                BEClasses.Clear();
                IRepositoryClasses.Clear();
                RepositoryClasses.Clear();
                BLClasses.Clear();
                for (int i = 0; i < lstTabels.CheckedItems.Count; i++)
                {
                    BEClasses.Add(lstTabels.CheckedItems[i].ToString(), generateBEClass(lstTabels.CheckedItems[i].ToString()));
                    IRepositoryClasses.Add(lstTabels.CheckedItems[i].ToString(), generateIRepositoryClass(lstTabels.CheckedItems[i].ToString()));
                    RepositoryClasses.Add(lstTabels.CheckedItems[i].ToString(), generateRepositoryClass(lstTabels.CheckedItems[i].ToString()));
                    BLClasses.Add(lstTabels.CheckedItems[i].ToString(), generateBLClass(lstTabels.CheckedItems[i].ToString()));
                }

                txtBE.Text = BEClasses.ElementAt(0).Value;
                txtIRepository.Text = IRepositoryClasses.ElementAt(0).Value;
                txtRepository.Text = RepositoryClasses.ElementAt(0).Value;
                txtBL.Text = BLClasses.ElementAt(0).Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string generateBEClass(string tableName)
        {
            StringBuilder classText = new StringBuilder();

            try
            {
                classText.Append("using System;" + Environment.NewLine + "using System.Collections.Generic;" + Environment.NewLine + "using System.Linq;" + Environment.NewLine + "using System.Text;" + Environment.NewLine + "using System.Threading.Tasks;" + Environment.NewLine + Environment.NewLine + " namespace BE");
                classText.Append(Environment.NewLine + "{");
                classText.Append(Environment.NewLine + "\t" + "public class " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + " : BaseEntity");
                classText.Append(Environment.NewLine + "\t" + "{");
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.ConnString))
                {
                    conn.Open();
                    DataTable tableFiled = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName });
                    string ClassName = string.Empty;
                    StringBuilder constructorFields = new StringBuilder();
                    StringBuilder constructorDeclaration = new StringBuilder();

                    foreach (DataRow row in tableFiled.Rows)
                    {
                        if (!excludedColumns.Contains(row["COLUMN_NAME"].ToString()))
                        {
                            string fieldName = row["COLUMN_NAME"].ToString();
                            string fieldType = string.Empty;
                            bool isForeignKey = row["COLUMN_NAME"].ToString().EndsWith("ID");
                            bool isNullable;
                            bool isKey;
                            ClassName = fieldName[0].ToString().ToUpper() + (fieldName.EndsWith("ID") ? fieldName.Substring(1, fieldName.Length - 3) : fieldName.Substring(1));

                            using (OleDbCommand objComm = new OleDbCommand("SELECT " + "[" + fieldName + "]" + " FROM " + "[" + tableName + "]", conn))
                            {
                                using (OleDbDataReader reader = objComm.ExecuteReader(CommandBehavior.KeyInfo))
                                {
                                    DataTable schemaTable = reader.GetSchemaTable();
                                    fieldType = dataTypeConvert(schemaTable.Rows[0]["DataType"].ToString());
                                    isNullable = bool.Parse(schemaTable.Rows[0]["AllowDBNull"].ToString());
                                    isKey = bool.Parse(schemaTable.Rows[0]["IsKey"].ToString());
                                }
                            }

                            classText.Append(Environment.NewLine + "\t" + "\t" + @"[SqlFieldNameAttribute(""" + fieldName.ToLower() + @"""");
                            if (isForeignKey)
                                classText.Append(@", """ + ClassName + @""", ""id"", Relation.OneToOne");
                            classText.Append(")]");
                            if (isForeignKey)
                                classText.Append(Environment.NewLine + "\t" + "\t" + "public " + ClassName + " " + ClassName + " { get; set; }");
                            else
                                classText.Append(Environment.NewLine + "\t" + "\t" + "public " + fieldType + " " + ClassName + " { get; set; }");
                            classText.Append(Environment.NewLine);

                            constructorFields.Append(fieldType + " " + ClassName.ToLower() + ", ");
                            constructorDeclaration.Append(Environment.NewLine + "\t" + "\t" + "this." + ClassName + " = " + ClassName.ToLower() + ";");
                        }
                    }

                    constructorFields.Append("int id");
                    constructorDeclaration.Append(Environment.NewLine + "\t" + "\t" + "\t" + "this.ID = " + "id;");

                    classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "public " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "()");
                    classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                    classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "}");

                    classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "public " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "(");
                    classText.Append(constructorFields.ToString() + ")");
                    classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                    classText.Append(constructorDeclaration.ToString());
                    classText.Append(Environment.NewLine + "\t" + "\t" + "}");
                }

                classText.Append(Environment.NewLine + "\t" + "}");
                classText.Append(Environment.NewLine + "}");



                //txtBE.Text = classText.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return classText.ToString();
        }

        private string generateIRepositoryClass(string tableName)
        {
            StringBuilder classText = new StringBuilder();

            try
            {
                classText.Append("using System;" + Environment.NewLine + "using System.Collections.Generic;" + Environment.NewLine + "using System.Linq;" + Environment.NewLine + "using System.Text;" + Environment.NewLine + "using System.Threading.Tasks;");
                classText.Append(Environment.NewLine + Environment.NewLine + "namespace RepositoryInterfaces");
                classText.Append(Environment.NewLine + "{");
                classText.Append(Environment.NewLine + "\t" + "public interface " + "I" + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository");
                classText.Append(Environment.NewLine + "\t" + "{");
                classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "}");
                classText.Append(Environment.NewLine + "}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return classText.ToString();
        }

        private string generateRepositoryClass(string tableName)
        {
            StringBuilder classText = new StringBuilder();

            try
            {
                classText.Append("using System;" + Environment.NewLine + "using System.Collections.Generic;" + Environment.NewLine + "using System.Linq;" + Environment.NewLine + "using System.Text;" + Environment.NewLine + "using System.Threading.Tasks;" + Environment.NewLine + "using BE;" + Environment.NewLine + "using RepositoryInterfaces;");
                classText.Append(Environment.NewLine + Environment.NewLine + "namespace Repositories");
                classText.Append(Environment.NewLine + "{");
                classText.Append(Environment.NewLine + "\t" + "public class " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository" + " : " + "GenericRepository<BE." + tableName[0].ToString().ToUpper() + tableName.Substring(1) + ">, I" + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository");
                classText.Append(Environment.NewLine + "\t" + "{");
                classText.Append(Environment.NewLine + "\t" + "\t" + "public " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository()");
                classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "}");
                classText.Append(Environment.NewLine + "\t" + "}");
                classText.Append(Environment.NewLine + "}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return classText.ToString();
        }

        private string generateBLClass(string tableName)
        {
            StringBuilder classText = new StringBuilder();
            try
            {
                classText.Append("using System;" + Environment.NewLine + "using System.Collections.Generic;" + Environment.NewLine + "using System.Linq;" + Environment.NewLine + "using System.Text;" + Environment.NewLine + "using System.Threading.Tasks;" + Environment.NewLine + "using Repositories;" + Environment.NewLine + "using BE;" + Environment.NewLine + "using System.Data;" + Environment.NewLine + "using System.Web.Security;");
                classText.Append(Environment.NewLine + Environment.NewLine + "namespace BL");
                classText.Append(Environment.NewLine + "{");
                classText.Append(Environment.NewLine + "\t" + "public class " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "BL");
                classText.Append(Environment.NewLine + "\t" + "{");

                //GetAll
                classText.Append(Environment.NewLine + "\t" + "\t" + "public List<BE." + tableName[0].ToString().ToUpper() + tableName.Substring(1) + ">" + " GetAll()");
                classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "return new " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository().GetAll()");
                classText.Append(Environment.NewLine + "\t" + "\t" + "}");

                //Insert
                classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "public int Save(" + "BE." + tableName[0].ToString().ToUpper() + tableName.Substring(1) + " " + tableName.ToLower() + ")");
                classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository repository = new " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository();");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "if(" + tableName.ToLower() + ".id > 0)");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "\t" + "return repository.Update(" + tableName.ToLower() + ");");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "else");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "\t" + "return repository.Insert(" + tableName.ToLower() + ");");
                classText.Append(Environment.NewLine + "\t" + "\t" + "}");

                //Delete
                classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "public bool Delete(" + "BE." + tableName[0].ToString().ToUpper() + tableName.Substring(1) + " " + tableName.ToLower() + ")");
                classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "return new " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository().Delete(" + tableName.ToLower() + ")");
                classText.Append(Environment.NewLine + "\t" + "\t" + "}");

                //GetByID
                classText.Append(Environment.NewLine + Environment.NewLine + "\t" + "\t" + "public BE." + tableName[0].ToString().ToUpper() + tableName.Substring(1) + " Get" + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "(int id)");
                classText.Append(Environment.NewLine + "\t" + "\t" + "{");
                classText.Append(Environment.NewLine + "\t" + "\t" + "\t" + "return new " + tableName[0].ToString().ToUpper() + tableName.Substring(1) + "Repository().GetByID(id)");
                classText.Append(Environment.NewLine + "\t" + "\t" + "}");

                classText.Append(Environment.NewLine + "\t" + "}");
                classText.Append(Environment.NewLine + "}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return classText.ToString();
        }

        private string dataTypeConvert(string datatype)
        {
            switch (datatype)
            {
                case "System.String": return "string"; break;
                case "System.Boolean": return "bool"; break;
                case "System.Int32": return "int"; break;
                case "System.DateTime": return "datetime"; break;
                case "System.Double": return "double"; break;
                default: return datatype;
            }
        }

        private void lstTabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (BEClasses.ContainsKey(lstTabels.SelectedItem.ToString()))
                    txtBE.Text = BEClasses[lstTabels.SelectedItem.ToString()];
                else
                    txtBE.Text = string.Empty;

                if (IRepositoryClasses.ContainsKey(lstTabels.SelectedItem.ToString()))
                    txtIRepository.Text = IRepositoryClasses[lstTabels.SelectedItem.ToString()];
                else
                    txtIRepository.Text = string.Empty;

                if (RepositoryClasses.ContainsKey(lstTabels.SelectedItem.ToString()))
                    txtRepository.Text = RepositoryClasses[lstTabels.SelectedItem.ToString()];
                else
                    txtRepository.Text = string.Empty;

                if (BLClasses.ContainsKey(lstTabels.SelectedItem.ToString()))
                    txtBL.Text = BLClasses[lstTabels.SelectedItem.ToString()];
                else
                    txtBL.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTabels.Items.Count; i++)
                lstTabels.SetItemChecked(i, true);
        }

        private void btnSaveClasses_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (Properties.Settings.Default.Folder != string.Empty)
                    dialog.SelectedPath = Properties.Settings.Default.Folder;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.SelectedPath != string.Empty)
                    {
                        Properties.Settings.Default.Folder = dialog.SelectedPath;
                        Properties.Settings.Default.Save();
                    }
                    for (int i = 0; i < BEClasses.Count; i++)
                    {
                        using (TextWriter tw = new StreamWriter(dialog.SelectedPath + "//" + BEClasses.ElementAt(i).Key[0].ToString().ToUpper() + BEClasses.ElementAt(i).Key.Substring(1) + ".cs", false))
                        {
                            tw.Write(BEClasses.ElementAt(i).Value);
                            //tw.Close();
                        }
                    }
                    for (int i = 0; i < IRepositoryClasses.Count; i++)
                    {
                        using (TextWriter tw = new StreamWriter(dialog.SelectedPath + "//" + "I" + IRepositoryClasses.ElementAt(i).Key[0].ToString().ToUpper() + IRepositoryClasses.ElementAt(i).Key.Substring(1) + "Repository.cs", false))
                        {
                            tw.Write(IRepositoryClasses.ElementAt(i).Value);
                            //tw.Close();
                        }
                    }
                    for (int i = 0; i < RepositoryClasses.Count; i++)
                    {
                        using (TextWriter tw = new StreamWriter(dialog.SelectedPath + "//" + RepositoryClasses.ElementAt(i).Key[0].ToString().ToUpper() + RepositoryClasses.ElementAt(i).Key.Substring(1) + "Repository.cs", false))
                        {
                            tw.Write(RepositoryClasses.ElementAt(i).Value);
                            //tw.Close();
                        }
                    }
                    for (int i = 0; i < BLClasses.Count; i++)
                    {
                        using (TextWriter tw = new StreamWriter(dialog.SelectedPath + "//" + BLClasses.ElementAt(i).Key[0].ToString().ToUpper() + RepositoryClasses.ElementAt(i).Key.Substring(1) + "BL.cs", false))
                        {
                            tw.Write(BLClasses.ElementAt(i).Value);
                            //tw.Close();
                        }
                    }

                    MessageBox.Show("Classes successfully saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
