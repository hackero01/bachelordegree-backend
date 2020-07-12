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

        public static string contorel = @"SELECT a.id_materie,a.numar_picati,a.numar_trecuti,b.nume_materie,a.id_utilizator
FROM tbl_numarStundetiPicati a
INNER JOIN tbl_materii b ON a.id_materie=b.id_materie
INNER JOIN tbl_utilizatori c ON c.id_utilizator=a.id_utilizator
WHERE a.id_utilizator =@idUtilizator";

        public static string contorel1 = @"SELECT a.id_materie,a.numar_picati,a.numar_trecuti,b.nume_materie,a.id_utilizator
FROM tbl_numarStundetiPicati a
INNER JOIN tbl_materii b ON a.id_materie=b.id_materie
INNER JOIN tbl_utilizatori c ON c.id_utilizator=a.id_utilizator
WHERE a.id_materie =@idMaterie";
        public static string loginUpdate = @" UPDATE [dbo].[tbl_utilizatori] SET conectat=@conectat where id_utilizator=@id_utilizator";
        public static string checkIfisLogged = @"select [conectat] FROM [dbo].[tbl_utilizatori] where [id_utilizator]=@id_utilizator";
        public static string countAccount = @"SELECT COUNT (*) from [dbo].[tbl_utilizatori]";
        public static string countTeachers = @"SELECT COUNT (*) from [dbo].[tbl_profesori]";
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
        public static string stergeExamen = @"DELETE FROM     [dbo].tbl_exams WHERE [exam_id]=@exam_id";
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
        public static string updatenr = @"UPDATE tbl_numarStundetiPicati
SET numar_picati = (SELECT numar_picati FROM tbl_numarStundetiPicati where id_materie=@idMaterie) + 1
WHERE id_materie = @idMaterie";
 public static string updatenr1 = @"UPDATE tbl_numarStundetiPicati
SET numar_trecuti = (SELECT numar_trecuti FROM tbl_numarStundetiPicati where id_materie=@idMaterie) + 1
WHERE id_materie = @idMaterie";
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

INNER JOIN [dbo].tbl_specializari d ON d.id_specializare= r.id_specializare where r.id_specializare=@idSpecializare";

        public static string autoEnrollatCourses = @"INSERT INTO dbo.[tbl.evidenta_stundeti_materii] (id_utilizator, id_materie, id_specializare)
                                                    SELECT a.id_utilizator, b.id_materie,a.id_specializare
                                                    FROM dbo.tbl_studenti a
                                                    INNER JOIN dbo.tbl_materii b ON a.id_specializare=b.id_specializare
                                                    WHERE a.id_specializare = @idSpecializare"; 

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

        public static string selectAllCourseById = @"SELECT 
                                                   [id_materie]
                                                  ,[id_specializare]
                                                  ,[id_utilizator]
                                              FROM [portalStudenti].[dbo].[tbl_materii] WHERE [id_specializare]=@idSpecializare";

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
        public static string venituriGenerate = @"SELECT SUM(valoare),a.id_materie
FROM tbl_restantieri a
INNER JOIN tbl_materii b ON a.id_materie=b.id_materie
WHERE b.id_utilizator=@idUtilizator
group by a.id_materie;";
        public static string countStudents = @"select sum(a.numarStudenti) 
  from (
          select count(*) as numarStudenti 
          from dbo.[tbl.evidenta_stundeti_materii]
           where  id_materie=@idMaterie
       ) as a";
        public static string a = @"SELECT

a.id_utilizator,
b.nume,b.prenume
,a.an_studiu
FROM dbo.tbl_studenti a
INNER JOIN dbo.tbl_utilizatori b ON b.id_utilizator=a.id_utilizator
INNER JOIN dbo.[tbl.evidenta_stundeti_materii] c ON c.id_utilizator=a.id_utilizator

where a.id_specializare=@idSpecializare and c.id_materie=@idMaterie";
        public static string getAllCourseWhatHeTeach = @"SELECT [id_materie],[nume_materie],[id_specializare] FROM dbo.tbl_materii WHERE [id_utilizator]=@idUtilizator";
        public static string getProgramID = @"SELECT [id_materie],[nume_materie],a.[id_specializare],b.[nume_specializare]
FROM dbo.tbl_materii a
INNER JOIN tbl_specializari b ON a.id_specializare=b.id_specializare
WHERE [id_materie]=@idMaterie";
        public static string insertExam = @"INSERT INTO [dbo].[tbl_exams]
           ([id_specializare]
           ,[id_materie]
           ,[data]
           ,[id_utilizator]
           ,[timp]
           ,[ora_examen],[an_studiu])
     VALUES
          (@idSpecializare,@idMaterie,@data,@idUtilizator,@timp,@oraExamen,@anStudiu)";
        public static string passedStudent = @"SELECT COUNT(*) FROM tbl_note WHERE nota >=5 and id_materie = @idMaterie";
        public static string failedStudent = @"SELECT COUNT(*) FROM tbl_note WHERE nota < 5 and id_materie = @idMaterie";
        public static string countTeacherExams = @"SELECT COUNT(*) FROM tbl_exams WHERE id_utilizator = @idUtilizator";
        public static string insereazaRestantieru = @"INSERT INTO [dbo].[tbl_numarStundetiPicati]
           ([id_materie]
           ,[numar]) VALUES (@idMaterie,@count)";
        public static string getExamListByIdOfTeacher = @"SELECT a.[exam_id]
      ,a.[id_specializare]  
      ,a.[id_materie]
      ,a.[data]
,a.[an_studiu]
    ,b.nume_specializare
      ,a.[timp]
      ,a.[ora_examen]
	  ,c.nume_materie
  FROM [dbo].[tbl_exams] a
  INNER JOIN dbo.tbl_specializari b ON b.id_specializare=a.id_specializare
  INNER JOIN dbo.tbl_materii c ON c.id_materie=a.id_materie
  WHERE a.[id_utilizator]=@idUtilizator";
        public static string getExamListOfUserById = @"SELECT a.[exam_id]
      ,a.[id_specializare]  
      ,a.[id_materie]
      ,a.[data]
,a.[an_studiu]
    ,b.nume_specializare
      ,a.[timp]
      ,a.[ora_examen]
	  ,c.nume_materie
  FROM [dbo].[tbl_exams] a
  INNER JOIN dbo.tbl_specializari b ON b.id_specializare=a.id_specializare
  INNER JOIN dbo.tbl_materii c ON c.id_materie=a.id_materie
  INNER JOIN dbo.tbl_studenti d ON d.an_studiu=a.an_studiu
  WHERE a.id_specializare=@idSpecializare and d.an_studiu=@anStudiu and d.id_utilizator=@idUtilizator";
        // Student zone // 
        public static string getStudentInformation = @"SELECT 
		  u.[id_utilizator]
		  ,u.[id_specializare]
		  ,u.[nr_credite]
		  ,u.[an_studiu],
		 b.nume_specializare
	  FROM [portalStudenti].[dbo].[tbl_studenti] u
	  INNER JOIN dbo.tbl_specializari b ON b.id_specializare=u.id_specializare
	  where u.id_utilizator=@idUtilizator";
        public static string getGradeByIdOfStudent = @"SELECT 
      [nota]
      ,a.[semestru]
      ,a.[an_studiu]
	  ,b.nume_materie
	  ,c.nume,c.prenume
  FROM [portalStudenti].[dbo].[tbl_note] a
  INNER JOIN tbl_materii b ON b.id_materie=a.id_materie
  INNER JOIN tbl_utilizatori c ON c.id_utilizator=a.id_utilizator
  WHERE a.id_utilizator=@idUtilizator";
        public static string countPassedExamByStudentId = @"SELECT COUNT(nota)
                                                            FROM tbl_note
                                                            WHERE id_utilizator=@idUtilizator and nota >=5";
        public static string sumaDatorata = @"SELECT SUM(valoare)
                                            FROM tbl_restantieri
                                            WHERE id_utilizator=@idUtilizator";
        public static string getListOfStudentClassById = @"SELECT b.nume,b.prenume,a.id_utilizator
                                                            from tbl_studenti a
                                                            INNER JOIN tbl_utilizatori b ON a.id_utilizator=b.id_utilizator
                                                            WHERE a.id_specializare=@idSpecializare and a.an_studiu=@anStudiu";
    }
}
 