using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Summary description for main_class
/// </summary>
public class main_class
{
	public main_class()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Convert_to_Midaly(string ShamsiDate, string time)
    {
        string str = "";
        string year = "";
        string month = "";
        string day = "";
        string hour = "";
        string min = "";
        string sec = "";
        DateTime dtt;


        FarsiLibrary.Utils.PersianDate pd = new FarsiLibrary.Utils.PersianDate(ShamsiDate);
        dtt = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(pd);

        year = dtt.Year.ToString();
        month = dtt.Month.ToString();
        day = dtt.Day.ToString();
        if (month.Length == 1) { month = "0" + month; }
        if (day.Length == 1) { day = "0" + day; }
        DateTime dt = Convert.ToDateTime(year + "/" + month + "/" + day + " " + time);



        year = dt.Year.ToString();
        month = dt.Month.ToString();
        day = dt.Day.ToString();
        hour = dt.Hour.ToString();
        min = dt.Minute.ToString();
        sec = dt.Second.ToString();

        if (month.Length == 1) { month = "0" + month; }
        if (day.Length == 1) { day = "0" + day; }
        if (hour.Length == 1) { hour = "0" + hour; }
        if (min.Length == 1) { min = "0" + min; }
        if (sec.Length == 1) { sec = "0" + sec; }


        str = year + "/" + month + "/" + day + " " + hour + ":" + min + ":" + sec;

        return str;

    }
    public string Convert_to_Midaly(string ShamsiDate)
    {
        string str = "";
        string year = "";
        string month = "";
        string day = "";

        DateTime dtt;


        FarsiLibrary.Utils.PersianDate pd = new FarsiLibrary.Utils.PersianDate(ShamsiDate);
        dtt = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(pd);

        year = dtt.Year.ToString();
        month = dtt.Month.ToString();
        day = dtt.Day.ToString();
        if (month.Length == 1) { month = "0" + month; }
        if (day.Length == 1) { day = "0" + day; }
        DateTime dt = Convert.ToDateTime(year + "/" + month + "/" + day);

        year = dt.Year.ToString();
        month = dt.Month.ToString();
        day = dt.Day.ToString();

        if (month.Length == 1) { month = "0" + month; }
        if (day.Length == 1) { day = "0" + day; }

        str = year + "/" + month + "/" + day + " ";

        return str;

    }
    public string Convert_to_Shamsi(DateTime dt)
    {
        string str = "";

        FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(dt);


        string year = "";
        string month = "";
        string day = "";


        year = pd.Year.ToString();
        month = pd.Month.ToString();
        day = pd.Day.ToString();

        if (month.Length == 1) { month = "0" + month; }
        if (day.Length == 1) { day = "0" + day; }

        str = year + "/" + month + "/" + day;

        return str;

    }
    public string Convert_to_standard_time(TimeSpan tm)
    {
        string str = "";
        string hour = "";
        string min = "";
        string sec = "";

        hour = tm.Hours.ToString();
        min = tm.Minutes.ToString();
        sec = tm.Seconds.ToString();

        if (hour.Length == 1) { hour = "0" + hour; }
        if (min.Length == 1) { min = "0" + min; }
        if (sec.Length == 1) { sec = "0" + sec; }

        str = hour + ":" + min + ":" + sec;

        return str;

    }
    public string get_connection_string()
    {
        System.Configuration.Configuration rootWebConfig =
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~\\");
        System.Configuration.ConnectionStringSettings connString;

        connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ProjectMeterConnectionString"];
        if (connString != null) { return connString.ConnectionString.ToString(); }
        else
        {
            return "";
        }
    }

    public bool check_username_valid(int userid, int pageid)
    {
        bool ok = true;
        SqlConnection sc = new SqlConnection(get_connection_string());
        sc.Open();
        SqlCommand sqlcm = new SqlCommand("select top 1 * from tbl_users_premissions where p_user_link = " + userid.ToString() + " and p_module_link = " + pageid.ToString()+" order by p_id desc",sc);
        SqlDataReader sqldr = sqlcm.ExecuteReader();
        if (sqldr.HasRows)
        {
            
            {
                while (sqldr.Read())
                {
                    if (Convert.ToInt16(sqldr["p_permission"].ToString()) != 1)
                    {
                        ok = false;
                    }
                }
            }
        }
        sqldr.Close();
        sc.Close();
        return ok;
    }

    public bool check_user_premission(string username, string password, string module_name, int usertype)
    {
        bool ok = true;
       SqlConnection sc = new SqlConnection(get_connection_string());
        sc.Open();
        SqlCommand sqlcm = new SqlCommand("select top 1 * from tbl_users where u_user_name = '" + username.ToString() + "' and u_password = '" + password.ToString() + "' and u_user_type=" + usertype.ToString() + "  order by p_id desc", sc);
        SqlDataReader sqldr = sqlcm.ExecuteReader();
        if (sqldr.HasRows)
        {
            while (sqldr.Read())
            {
                  SqlCommand sqlcm1 = new SqlCommand("select top 1 * from tbl_users_modules where m_name = " + module_name.ToString(),sc);
                  SqlDataReader sqldr1 = sqlcm1.ExecuteReader();
                if (sqldr1.HasRows)
                {
                    ok = check_username_valid( Convert.ToInt16(sqldr["u_id"].ToString()), Convert.ToInt16(sqldr1["m_id"].ToString()));
                }
                     else 
                {
                    ok=false;
                }
                sqldr1.Close();
            }
        }
        else 
            {
                ok = false;
            }

                sqldr.Close();
        sc.Close();
        return ok;

    }

    public bool is_user_valid(string username, string password)
    {
        bool ok = false;
       SqlConnection sc = new SqlConnection(get_connection_string());
        sc.Open();
        SqlCommand sqlcm = new SqlCommand("select top 1 * from tbl_users where u_user_name = '" + username.ToString() + "' and u_password = '" + password.ToString() +"'  ", sc);
        SqlDataReader sqldr = sqlcm.ExecuteReader();
        if (sqldr.HasRows)
        {
            ok = true;
        }

        sqldr.Close();
        sc.Close();

        return ok;
    }





    public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {
        // Convert strings into byte arrays.
        // Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        // encoding.
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

        // Convert our plaintext into a byte array.
        // Let us assume that plaintext contains UTF8-encoded characters.
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        // First, we must create a password, from which the key will be derived.
        // This password will be generated from the specified passphrase and 
        // salt value. The password will be created using the specified hash 
        // algorithm. Password creation can be done in several iterations.
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase,
                                                        saltValueBytes,
                                                        hashAlgorithm,
                                                        passwordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        byte[] keyBytes = password.GetBytes(keySize / 8);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged symmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC;

        // Generate encryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key 
        // bytes.
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                         keyBytes,
                                                         initVectorBytes);

        // Define memory stream which will be used to hold encrypted data.
        MemoryStream memoryStream = new MemoryStream();

        // Define cryptographic stream (always use Write mode for encryption).
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                     encryptor,
                                                     CryptoStreamMode.Write);
        // Start encrypting.
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

        // Finish encrypting.
        cryptoStream.FlushFinalBlock();

        // Convert our encrypted data from a memory stream into a byte array.
        byte[] cipherTextBytes = memoryStream.ToArray();

        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();

        // Convert encrypted data into a base64-encoded string.
        string cipherText = Convert.ToBase64String(cipherTextBytes);

        // Return encrypted string.
        return cipherText;
    }
    public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {
        // Convert strings defining encryption key characteristics into byte
        // arrays. Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8
        // encoding.
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

        // Convert our ciphertext into a byte array.
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        // First, we must create a password, from which the key will be 
        // derived. This password will be generated from the specified 
        // passphrase and salt value. The password will be created using
        // the specified hash algorithm. Password creation can be done in
        // several iterations.
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase,
                                                        saltValueBytes,
                                                        hashAlgorithm,
                                                        passwordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        byte[] keyBytes = password.GetBytes(keySize / 8);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged symmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC;

        // Generate decryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key 
        // bytes.
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                         keyBytes,
                                                         initVectorBytes);

        // Define memory stream which will be used to hold encrypted data.
        MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

        // Define cryptographic stream (always use Read mode for encryption).
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                      decryptor,
                                                      CryptoStreamMode.Read);

        // Since at this point we don't know what the size of decrypted data
        // will be, allocate the buffer long enough to hold ciphertext;
        // plaintext is never longer than ciphertext.
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        // Start decrypting.
        int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                   0,
                                                   plainTextBytes.Length);

        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();

        // Convert decrypted data into a string. 
        // Let us assume that the original plaintext string was UTF8-encoded.
        string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                   0,
                                                   decryptedByteCount);

        // Return decrypted string.   
        return plainText;
    }
    public string Encode(string str)
    {
        string plainText = str;    // original plaintext

        string passPhrase = "bahmanymb@gmail.com";        // can be any string
        string saltValue = "mohammad_mrb@yahoo.com";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 2;                  // can be any number
        string initVector = "@1B2ceD4e5F6g7H8"; // must be 16 bytes
        int keySize = 128;                // can be 192 or 128
        return Encrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);


    }
    public string Decode(string str)
    {
        string plainText = str;    // original plaintext

        string passPhrase = "bahmanymb@gmail.com";        // can be any string
        string saltValue = "mohammad_mrb@yahoo.com";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 2;                  // can be any number
        string initVector = "@1B2ceD4e5F6g7H8"; // must be 16 bytes
        int keySize = 128;                // can be 192 or 128
        return Decrypt(plainText, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);


    }




}
