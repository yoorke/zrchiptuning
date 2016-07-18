using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Relation
    {
        OneToMany,
        OneToOne
    }

    public class SqlFieldNameAttribute : Attribute
    {
        public bool IsKey { get; set; }
        public string SqlFieldName { get; set; }
        public string SqlForeignKeyFieldName { get; set; }
        public string SqlForeignClassName { get; set; }
        public Relation SqlRelation { get; set; }
        public string Action { get; set; }

        public SqlFieldNameAttribute(string sqlFieldName)
        {
            this.IsKey = false;
            this.SqlFieldName = sqlFieldName;
            this.SqlForeignKeyFieldName = string.Empty;
            this.SqlForeignClassName = string.Empty;
            this.SqlRelation = Relation.OneToOne;
        }

        public SqlFieldNameAttribute(string sqlFieldName, bool isKey)
        {
            this.IsKey = IsKey;
            this.SqlFieldName = sqlFieldName;
            this.SqlForeignKeyFieldName = string.Empty;
            this.SqlForeignClassName = string.Empty;
            this.SqlRelation = Relation.OneToOne;
        }

        public SqlFieldNameAttribute(string sqlFieldName, string sqlForeignClassName, string sqlForeignKeyFieldName)
        {
            this.IsKey = false;
            this.SqlFieldName = SqlFieldName;
            this.SqlForeignKeyFieldName = sqlForeignKeyFieldName;
            this.SqlForeignClassName = sqlForeignClassName;
            this.SqlRelation = Relation.OneToOne;
        }

        public SqlFieldNameAttribute(string sqlFieldName, string sqlForeignClassName, string sqlForeignKeyFieldName, Relation relation)
        {
            this.IsKey = false;
            this.SqlFieldName = sqlFieldName;
            this.SqlForeignKeyFieldName = sqlForeignKeyFieldName;
            this.SqlForeignClassName = sqlForeignClassName;
            this.SqlRelation = relation;
        }

        public SqlFieldNameAttribute(string sqlFieldName, string sqlForeignClassName, string sqlForeignKeyFieldName, Relation relation, string action)
        {
            this.IsKey = false;
            this.SqlFieldName = sqlFieldName;
            this.SqlForeignKeyFieldName = sqlForeignKeyFieldName;
            this.SqlForeignClassName = sqlForeignClassName;
            this.SqlRelation = relation;
            this.Action = action;
        }
    }
}
