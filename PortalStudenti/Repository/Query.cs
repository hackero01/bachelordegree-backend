using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Repository
{
    public class Query
    {
        public static string getAnnouncement = @"";
        public int conectat = 1;
        public static string loginCheck = @"SELECT [id_utilizator] ,[nume],[prenume],[email],[parola],[adresa],[nr_telefon],[conectat],r.[denumire] AS statut,r.[id_rol],r.denumire
                                          FROM [dbo].[tbl_utilizatori] u
                                          INNER JOIN [dbo].[tbl_roluri] r ON r.[id_rol]=u.[id_rol]  
										  where [email] = @email";

        public static string getAllUserInformation = @"SELECT [id_utilizator] ,[nume],[prenume],[email],[parola],[adresa],[nr_telefon],[conectat],r.[denumire] AS statut,r.[id_rol],r.denumire
                                          FROM [dbo].[tbl_utilizatori] u
                                          INNER JOIN [dbo].[tbl_roluri] r ON r.[id_rol]=u.[id_rol]  
										  where [id_utilizator] = @idUtilizator";


        public static string loginUpdate = @" UPDATE [dbo].[tbl_utilizatori] SET conectat=@conectat where id_utilizator=@id_utilizator";
        public static string checkIfisLogged = @"select [conectat] FROM [dbo].[tbl_utilizatori] where [id_utilizator]=@id_utilizator";
        public static string countAccount = @"SELECT COUNT (*) from [dbo].[tbl_utilizatori]";
        public static string countCourse = @"SELECT COUNT (*) from [dbo].tbl_specializari";
        public static string updateAccount = @" UPDATE [dbo].[tbl_utilizatori] SET [nume]=@nume,[prenume]=@prenume,[email]=@email,[parola]=@parola,[adresa]=@adresa,[nr_telefon]=@numarTelefon WHERE [id_utilizator]=@idUtilizator";
        public static string createAccount = @"INSERT INTO [dbo].[tbl_utilizatori]
           ([email]
           ,[parola]
           ,[nume]
           ,[prenume]
           ,[adresa]
           ,[nr_telefon]
           ,[conectat]
           ,[id_rol])
         VALUES
           (@email,@parola,@nume,@prenume,@adresa,@numarTelefon,@conectat,@idRol)";
        // Management specializare //

        public static string creeazaSpecializare = @"INSERT INTO [dbo].[tbl_specializari] ([nume_specializare],[locuri_disponibile],[locuri_ocupate],[ani_studiu]) VALUES(@numeSpecializare,@locuriDisponibile,@locuriOcupate,@aniStudiu)";
        public static string incarcaSpecializari = @"SELECT [id_specializare],[nume_specializare],[locuri_disponibile],[locuri_ocupate],[ani_studiu] from [dbo].tbl_specializari";
        public static string stergeSpecializari = @"DELETE FROM     [dbo].tbl_specializari WHERE [id_specializare]=@id_specializare";
        public static string modificaSpecializari = @" UPDATE [dbo].tbl_specializari SET [nume_specializare]=@nume_specializare, [locuri_disponibile]=@locuri_disponibile,[locuri_ocupate]=@locuri_ocupate,[ani_studiu]=@ani_studiu WHERE [id_specializare]=@idSpecializare";
        public static string detaliiSpecializare = @"SELECT [id_specializare],[nume_specializare],[locuri_disponibile],[locuri_ocupate],[ani_studiu] from [dbo].tbl_specializari where [id_specializare]=@id_specializare";
        // --------------------- // 

        // Management conturi // 
        public static string incarcaConturi = @"SELECT  u.[id_utilizator]
                                              ,u.[nume]
                                              ,[prenume]
                                              ,[email]
                                              ,[parola]
                                              ,[adresa]
                                              ,[nr_telefon]
                                              ,[conectat]
                                              ,r.[denumire] AS [statut],
                                                r.[id_rol]
                                          FROM [dbo].[tbl_utilizatori] u
                                          INNER JOIN [dbo].[tbl_roluri] r ON u.[id_rol]=r.[id_rol]";
        public static string stergeCont = @"DELETE FROM [dbo].[tbl_utilizatori] WHERE [id_utilizator]=@id_utilizator";
        public static string detaliiCont = @"SELECT  u.[id_utilizator]
                                              ,u.[nume]
                                              ,[prenume]
                                              ,[email]
                                              ,[parola]
                                              ,[adresa]
                                              ,[nr_telefon]
                                              ,[conectat]
                                              ,r.[denumire] AS [statut],
                                                r.[id_rol]
        FROM[dbo].[tbl_utilizatori]
        u
       INNER JOIN[dbo].[tbl_roluri] r ON u.[id_rol]=r.[id_rol] where [id_utilizator]=@idUtilizator";

        public static string adminUpdateAccount = @" UPDATE [dbo].[tbl_utilizatori] SET [nume]=@nume,[prenume]=@prenume,[email]=@email,[parola]=@parola,[adresa]=@adresa,[nr_telefon]=@numarTelefon,[conectat]=@conectat WHERE [id_utilizator]=@id_utilizator";

        // Management membrii specializari

        public static string incarcaMembriiSpecializari = @"SELECT  r.[id]
      ,r.[id_utilizator]
      ,r.[id_specializare]
      ,[nr_credite]
      ,[an_studiu]
	  ,c.nume
	  ,c.prenume
	  ,d.nume_specializare
  FROM[portalStudenti].[dbo].[tbl_studenti]
        r
INNER JOIN[dbo].tbl_utilizatori c ON c.[id_utilizator]= r.id_utilizator

INNER JOIN [dbo].tbl_specializari d ON d.id_specializare= r.id_specializare";

        public static string incarcaMembriiSpecializarii = @"SELECT [id],[id_specializare],[id_utilizator] FROM  [dbo].[tbl_membrii_specializari]";
        //Management Roluri

        public static string getAllRoles = @" SELECT [id_rol]
                                              ,[denumire]
                                          FROM [dbo].[tbl_roluri]";


        // Management administrare cadre didactice

        public static string loadAllTeacher = @"SELECT  a.[id]
                                              ,a.[id_materie]
                                              ,a.[id_utilizator]
                                              ,a.[id_specializare]
	                                          ,c.nume,c.prenume
	                                          ,b.nume_materie
                                               ,d.nume_specializare
                                          FROM [portalStudenti].[dbo].[tbl_profesori] a
                                          INNER JOIN dbo.tbl_materii b ON b.id_materie=a.id_materie
                                          INNER JOIN dbo.tbl_utilizatori c ON c.id_utilizator=a.id_utilizator
                                           INNER JOIN dbo.tbl_specializari d ON d.id_specializare=a.id_specializare";
        public static string deleteTeacher = @"DELETE FROM [dbo].[tbl_profesori] WHERE [id]=@id";
        public static string loadTeacherDetails = @"SELECT a.[id]
                                                          , a.[id_materie]
                                                          , a.[id_utilizator]
                                                          , a.[id_specializare]
                                                          , c.nume, c.prenume
                                                          , b.nume_materie
														  ,d.nume_specializare
                                                           FROM [portalStudenti].[dbo].[tbl_profesori] a
                                                           INNER JOIN dbo.tbl_materii b ON b.id_materie= a.id_materie
                                                           INNER JOIN dbo.tbl_utilizatori c ON c.id_utilizator= a.id_utilizator
														   INNER JOIN dbo.tbl_specializari d ON d.id_specializare=a.id_specializare WHERE a.[id]=@id";
        public static string setTeacherCourse = @"UPDATE [dbo].[tbl_profesori] SET [id_materie]=@idMaterie WHERE [id]=@id";
        public static string getAllCourses = @"SELECT [id_materie]
                                                  ,[nume_materie]
                                                  ,[id_specializare]
                                                  ,[credite]
                                                  ,[semestru]
                                                  ,[an_studiu]
                                                  ,[id_utilizator]
                                              FROM [dbo].[tbl_materii]";

        // Teacher REPO
        //
        public static string getAllEnroledStudentsAtCourseByIdOfCourse = @"SELECT  a.[id]
                                                                      ,a.[id_utilizator]
                                                                      ,a.[id_materie]
                                                                      ,a.[id_specializare]
	                                                                  ,c.nume,c.prenume,b.nume_materie
                                                                  FROM [portalStudenti].[dbo].[tbl.evidenta_stundeti_materii] a
                                                                  INNER JOIN tbl_materii b ON b.id_materie=a.id_materie 
                                                                  INNER JOIN tbl_utilizatori c ON c.id_utilizator=a.id_utilizator WHERE a.id_materie=@idMaterie";

        public static string getNameOfCourse = @"SELECT  a.[id_materie]
      ,a.[nume_materie]
      ,c.[nume_specializare] AS nume_specializare
     ,a.[id_specializare]
      ,a.[credite]
      ,a.[semestru]
      ,a.[an_studiu]
      ,a.[id_utilizator]
	 
  FROM [portalStudenti].[dbo].[tbl_materii] a
  INNER JOIN dbo.tbl_utilizatori b ON b.id_utilizator=a.id_utilizator 
  inner join dbo.tbl_specializari c ON a.id_specializare=c.id_specializare WHERE a.id_utilizator=@idUtilizator";
    }
}