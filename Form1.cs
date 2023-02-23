using System.Data;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace your_Review
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            cbStatus.Items.Add("To Watch");
            cbStatus.Items.Add("Watching");
            cbStatus.Items.Add("Watched");

            cbUpStatus.Items.Add("To Watch");
            cbUpStatus.Items.Add("Watching");
            cbUpStatus.Items.Add("Watched");
           
        }
        

        #region image upload
        private void btnaddpics(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files (*.*)|*.*";
                opf.Title= "Select an Image";
                if (opf.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = opf.FileName;
                   image1.ImageLocation= imagelocation;
                }
            }
            catch(Exception ) 
            {
                MessageBox.Show("an error occured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnudatepic(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files (*.*)|*.*";
                opf.Title = "Select an Image";
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = opf.FileName;
                    picbox.ImageLocation = imagelocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnClickadd(object sender, EventArgs e)
        {

            Reviews task = new Reviews();
            if (txtScore.Text == string.Empty  )
            {
                txtScore.Text = "";

            }
            else
            {
                task.Score = Convert.ToInt32(txtScore.Text);

            }
                task.Title = txtTitle.Text;
                task.Genre = txtGenre.Text;
                task.Status = cbStatus.Text;
                task.image = image1.Image;
                task.CreatedTime = DateTime.Now; 
               SQL.AddToList(task);
          
        }
        private void btnMylistclick(object sender, EventArgs e)
        {
            List<Reviews> tempList = SQL.getmylist();
            dgvList.DataSource = tempList;

        }
       private void btnRemoveClick(object sender, EventArgs e)
        {
            Reviews task2= new Reviews();
            try
            {
                task2.Id = int.Parse(txtID.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);   
            }
            SQL.dellist(task2.Id);

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Reviews tasks = new Reviews();
            if (txtUpscore.Text== string.Empty)
            {

               txtUpscore.Text = "";

            }
            else
            {
                tasks.Score = Convert.ToInt32(txtUpscore.Text);

            }
       
            tasks.Id= int.Parse(txtIdUpdate.Text);
            tasks.Title  = txtupTitel.Text;
            tasks.Genre  = txtupGenre.Text;
            tasks.Status = cbUpStatus.Text;
            tasks.image  = picbox.Image;
            tasks.CreatedTime = DateTime.Now;
            SQL.updatelist(tasks.Id);

        }
    }
}