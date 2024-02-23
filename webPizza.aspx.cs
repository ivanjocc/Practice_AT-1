using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsControlleASP
{
    public partial class webPizza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblAdresse.Visible = false;
                txtAdresse.Visible = false;
                PanPrix.Visible = false;
                RemplirListePizzas();
                RemplirListeTaille();
                RemplirListeGarnitures();
                RemplirListeCroute();
            }
        }

        private void RemplirListeCroute()
        {
            ListItem elm = new ListItem();
            elm.Text = "normal (0 $)";
            elm.Value = "0";
            elm.Selected = true;
            lstRbtnCrust.Items.Add(elm);

            lstRbtnCrust.Items.Add(new ListItem("mince (0 $)", "0.0"));

            lstRbtnCrust.Items.Add(new ListItem("epaisse (1 $)", "1"));

            lstRbtnCrust.Items.Add(new ListItem("fournee fromage (2.5 $)", "2.5"));
        }

        private void RemplirListeGarnitures()
        {
            ListItem elm = new ListItem();
            elm.Text = "bacon et jambon (2.5 $)";
            elm.Value = "2.5";
            lstChkGarnitures.Items.Add(elm);

            lstChkGarnitures.Items.Add(new ListItem("champignon (1.5 $)", "1.5"));

            lstChkGarnitures.Items.Add(new ListItem("extra fromage (1 $)", "1"));

            lstChkGarnitures.Items.Add(new ListItem("pepperoni halal (2 $)", "2"));
            
        }

        protected void CalculerPrix()
        {
            PanPrix.Visible = true;

            decimal prixbase = 0;
            decimal livraison = 0;
            decimal soustot, total;
            decimal tax = 0.15m;
            decimal totalSansTax;
            decimal prixGarnitures = 0;
            decimal prixCrust = 0;
            string info;

            prixbase = Convert.ToDecimal(cboPizzas.SelectedItem.Value);

            prixbase = prixbase * Convert.ToDecimal(lstTailles.SelectedItem.Value);

            foreach (ListItem garniture in lstChkGarnitures.Items)
            {
                if (garniture.Selected)
                {
                    prixGarnitures += Convert.ToDecimal(garniture.Value);
                }
            }

            if (chkLivraison.Checked)
            {
                livraison = 5;
            }

            prixCrust += Convert.ToDecimal(lstRbtnCrust.SelectedItem.Value);

            soustot = prixbase + livraison + prixGarnitures + prixCrust;

            totalSansTax = soustot * tax;

            total = soustot + totalSansTax;

            info = "le prix de base est: " + prixbase + " $ <br>";
            info += "frais de livraison " + livraison + " $ <br>";
            info += "prix des garnitures " + prixGarnitures + " $ <br>";
            info += "prix de croute " + prixCrust+ " $ <br>";
            info += "---------------------------------------------------- <br>";
            info += "sous-total " + soustot+ " $ <br>";
            info += "tax (15%) " + Math.Round(totalSansTax, 2) + " $ <br>";
            info += "---------------------------------------------------- <br>";
            info += "total " + Math.Round(total, 2) + " $ <br>";


            lblPrix.Text = info;
        }

        private void RemplirListeTaille()
        {
            ListItem elm = new ListItem();
            elm.Text = "petite";
            elm.Value = "1";
            elm.Selected = true;
            lstTailles.Items.Add(elm);

            lstTailles.Items.Add(new ListItem("moyenne", "1.5"));

            lstTailles.Items.Add(new ListItem("grande", "2"));
        }

        private void RemplirListePizzas()
        {
            ListItem elm = new ListItem();
            elm.Text = "Faites votre choix";
            elm.Value = "0";
            cboPizzas.Items.Add(elm);

            elm = new ListItem();
            elm.Text = "L'italienne";
            elm.Value = "10";
            cboPizzas.Items.Add(elm);

            elm = new ListItem("la atunia", "9");
            cboPizzas.Items.Add(elm);

            cboPizzas.Items.Add(new ListItem("la choriperro", "11"));

            cboPizzas.Items.Add(new ListItem("la vegetarienne", "14"));

            cboPizzas.Items.Add(new ListItem("la halal", "3"));
        }

        protected void chkLivraison_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLivraison.Checked == true)
            {
                lblAdresse.Visible = true;
                txtAdresse.Visible = true;
                txtAdresse.Focus();
            }
            else
            {
                lblAdresse.Visible = false;
                txtAdresse.Visible = false;
            }

            if (cboPizzas.SelectedIndex != 0)
            {
                CalculerPrix();
            } else
            {
                PanPrix.Visible = false;
            }
        }

        protected void cboPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPizzas.SelectedIndex != 0)
            {
                CalculerPrix();
            }
        }

        protected void lstTailles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPizzas.SelectedIndex != 0)
            {
                CalculerPrix();
            } else
            {
                PanPrix.Visible = false;
            }
        }

        protected void lstChkGarnitures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPizzas.SelectedIndex != 0)
            {
                CalculerPrix();
            }
            else
            {
                PanPrix.Visible = false;
            }
        }

        protected void lstRbtnCrust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPizzas.SelectedIndex != 0)
            {
                CalculerPrix();
            }
            else
            {
                PanPrix.Visible = false;
            }
        }
    }
}