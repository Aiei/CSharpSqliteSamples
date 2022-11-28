using Microsoft.Data.Sqlite;

// Membuat variabel koneksi yang akan menghubungkan ke file database
// Dalam contoh ini, file database rpg.db diletakkan pada drive C
using (SqliteConnection koneksi = new SqliteConnection("Data Source=C:/rpg.db"))
{
    // Membuka koneksi ke database sqlite yang diset pada variabel koneksi
    koneksi.Open();

    // Mencetak teks id:
    Console.Write("Id: ");
    // Membaca input pengguna dan menyimpan isinya pada variabel characterId
    var characterId = Console.ReadLine();

    // Membuat variabel command yang akan menyimpan query sql
    SqliteCommand command = koneksi.CreateCommand();
    // Menulis query sql pada variabel command dengan parameter
    command.CommandText = 
    @"
        SELECT * 
        FROM characters 
        WHERE id = $id
    ";
    // Mengisi parameter id dengan isi variabel characterId
    command.Parameters.AddWithValue("$id", characterId);

    // Mengeksekusi perintah dan menyimpan hasilnya pada variabel reader
    using (SqliteDataReader reader = command.ExecuteReader())
    {
        // Melakukan perulangan untuk setiap baris dari tabel hasil
        while (reader.Read())
        {
            // Mencetak isi kolom character_name dan hit_points
            Console.WriteLine($"Character: {reader["character_name"]}, HP: {reader["hit_points"]}");
        }
    }
}