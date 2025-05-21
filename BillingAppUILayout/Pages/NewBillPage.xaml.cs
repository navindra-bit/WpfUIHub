using System.Data;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace SampleAppLogin.Pages
{
    /// <summary>
    /// Interaction logic for NewBillPage.xaml
    /// </summary>
    public partial class NewBillPage : Page
    {
        public string id;
        public NewBillPage(string userid)
        {
            InitializeComponent();
            id= userid;
            SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = AppUserinfo; Integrated security=true; encrypt = false");
            sqlConnection.Open();

            string sql = "Select * from PRODUCTS";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
            DataSet data = new DataSet();
            sqlData.Fill(data, "PRODUCTS");
            sqlConnection.Close();
            cmbProduct.DisplayMemberPath = "TITLE";
            cmbProduct.SelectedValuePath = "PRODUCTID";
            cmbProduct.ItemsSource = data.Tables["PRODUCTS"].DefaultView;
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbProduct.SelectedValue == null)
            {
                return;
            }
            SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = AppUserinfo; Integrated security=true; encrypt = false");
            sqlConnection.Open();

            string sql = "Select * from PRODUCTS where PRODUCTID =@PRODid";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PRODid", cmbProduct.SelectedValue);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if(dataReader.HasRows)
            {
                dataReader.Read();
                unitBox.Text = dataReader["STOCK_UNITS"].ToString();
                priceBox.Text = dataReader["PRICE"].ToString();

            }
            sqlCommand.Clone();

        }
        public int cartid = 0;
        public int count = 0;
        public decimal billtotal = 0;
        private void addtobillbnt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=NAVINDRA-M\\SQLEXPRESS; Initial Catalog = AppUserinfo; Integrated security=true; encrypt = false");
            sqlConnection.Open();

           
            SqlCommand sqlCommand = new SqlCommand("pr_bill", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userid", id);
            sqlCommand.Parameters.AddWithValue("@pid", cmbProduct.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@qty",Convert.ToInt32(Quantitybox.Text));
            sqlCommand.Parameters.AddWithValue("@defultcartid", cartid);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet= new DataSet();
            dataAdapter.Fill(dataSet,"product");
            count =dataSet.Tables["product"].Rows.Count-1;
            cartid = dataSet.Tables["product"].Rows[count].Field<int>("CARTID");
            billdata.ItemsSource = dataSet.Tables["product"].DefaultView;
            billtotal+= dataSet.Tables["product"].Rows[count].Field<Decimal>("TOTAL_PRICE");
            sqlConnection.Close();
            totalbox.Text = billtotal.ToString();
        }
    }
}
