using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarteRoom
{
    public partial class Manager1 : System.Web.UI.Page
    {
        private Logic logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();

            numOfManagers.Text = logic.numOf(1).ToString();
            numOfUsers.Text = logic.numOf(0).ToString();
        }

        protected void insertNewManager_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            if (!logic.isExist(((TextBox)Managers.FooterRow.FindControl("addManagerUsr")).Text))
            {
                SqlDataSource1.InsertParameters["usr"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerUsr")).Text;
                SqlDataSource1.InsertParameters["pass"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerPass")).Text;
                SqlDataSource1.InsertParameters["name"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerName")).Text;
                SqlDataSource1.InsertParameters["email"].DefaultValue = ((TextBox)Managers.FooterRow.FindControl("addManagerEmail")).Text;

                SqlDataSource1.Insert();
                Response.Redirect("Manager.aspx");
            }

            else
                ScriptManager.RegisterStartupScript(this, GetType(), "userExists", "userExists();", true);
        }

        protected void insertNewUser_Click(object sender, EventArgs e)
        {
            logic = new Logic();

            if (!logic.isExist(((TextBox)Managers.FooterRow.FindControl("addManagerUsr")).Text))
            {
                Users.InsertParameters["usr"].DefaultValue = ((TextBox)UsersTable.FooterRow.FindControl("addUserUsr")).Text;
                Users.InsertParameters["pass"].DefaultValue = ((TextBox)UsersTable.FooterRow.FindControl("addUserPass")).Text;
                Users.InsertParameters["name"].DefaultValue = ((TextBox)UsersTable.FooterRow.FindControl("users_addUserName")).Text;
                Users.InsertParameters["email"].DefaultValue = ((TextBox)UsersTable.FooterRow.FindControl("users_addUserEmail")).Text;

                Users.Insert();
                Response.Redirect("Manager.aspx");
            }

            else
                ScriptManager.RegisterStartupScript(this, GetType(), "userExists", "userExists();", true);
        }

        protected void insertClass_Click(object sender, EventArgs e)
        {
            Guid newGuid = Guid.NewGuid();
            classesSource.InsertParameters["id"].DefaultValue = newGuid.ToString();
            classesSource.InsertParameters["class_name"].DefaultValue = ((TextBox)ClassesTable.FooterRow.FindControl("classInsert")).Text;

            classesSource.Insert();
            Response.Redirect("Manager.aspx");
        }
    }
}