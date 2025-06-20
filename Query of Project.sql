
   SELECT 
             a.ApplicationID,
             a.ApplicationDate,
             a.ApplicationStatus,
             a.ApplicationTypeID AS AppTypeID,
             a.LastStatusDate,
             a.PaidFees,
             a.CreatedByUserID,
          
             at.ApplicationTypeTitle,
             at.ApplicationTypeID AS TypeID,
                   
              ldla.LocalDrivingLicenseApplicationID,
              ldla.ApplicationID AS LDLA_AppID,
              ldla.LicenseClassID AS LDLA_ClassID,
          
              lc.ClassName,
              lc.LicenseClassID,
          
              p.PersonID,
              p.FirstName,
              p.SecondName,
              p.ThirdName,
              p.LastName,
          
              u.UserID,
              u.UserName,

            (
        SELECT COUNT(*) 
        FROM TestAppointments TA
        JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
        WHERE 
            TA.LocalDrivingLicenseApplicationID = ldla.LocalDrivingLicenseApplicationID
            AND T.TestResult = 1
         ) AS [PassedTests]

          FROM Applications a
          INNER JOIN ApplicationTypes at ON a.ApplicationTypeID = at.ApplicationTypeID
          INNER JOIN LocalDrivingLicenseApplications ldla ON a.ApplicationID = ldla.ApplicationID
          INNER JOIN LicenseClasses lc ON ldla.LicenseClassID = lc.LicenseClassID
          INNER JOIN People p ON a.ApplicantPersonID = p.PersonID
          JOIN Users u ON a.CreatedByUserID = u.UserID
         
           WHERE ldla.LocalDrivingLicenseApplicationID = 38;







SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = 50;

 
 
 --/////////////////////////////*******************///////////////////////////////////////

 
 --/////////////////////////////*******************///////////////////////////////////////

 --/////////////////////////////*******************///////////////////////////////////////


	 select * from LocalDrivingLicenseApplications;
select * from Applications;


 --/////////////////////////////*******************///////////////////////////////////////


            SELECT      Applications.ApplicantPersonID, LocalDrivingLicenseApplications.LicenseClassID,
              Applications.ApplicationStatus
        FROM          Applications INNER JOIN
         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
		 where ApplicantPersonID=1 and LicenseClassID=1 and  ApplicationStatus=1;




		 --/////////////////////////////*******************///////////////////////////////////////


		 select LDLA.LocalDrivingLicenseApplicationID as [L.D.L AppID],LC.ClassName as [Driving Class]
          ,P.NationalNo as [NationalNo],(P.FirstName + ' ' + P.SecondName + ' ' +P.ThirdName + ' ' +P.LastName + ' ' ) as [FullName]
      ,A.ApplicationDate as [Application Date],

  (
    SELECT COUNT(*) 
    FROM TestAppointments TA
    JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
    WHERE 
        TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
        AND T.TestResult = 1
 ) AS [Passed Tests],



      case 
     when A.ApplicationStatus =1 then 'New'
      when A.ApplicationStatus =2 then 'Cancelled '
       when A.ApplicationStatus =3 then 'Completed'
        ELSE 'Unknown'
       end as [Status]
      
       
      from
      LocalDrivingLicenseApplications LDLA 

      join
      LicenseClasses LC on LC.LicenseClassID=LDLA.LicenseClassID 
     
       join
      Applications A on A.ApplicationID = LDLA.ApplicationID 
       join 
      People P  on P.PersonID = A.ApplicantPersonID



SELECT        TestAppointmentID as [Appointement ID], AppointmentDate, PaidFees, IsLocked
FROM            TestAppointments



  SELECT     TestAppointmentID as [Appointement ID], AppointmentDate, PaidFees, IsLocked
      FROM       TestAppointments TA
      where LocalDrivingLicenseApplicationID=36;


    select TA.TestAppointmentID as [Appointement ID],TA.AppointmentDate, TA.PaidFees, TA.IsLocked
	  FROM       TestAppointments TA 
	 join LocalDrivingLicenseApplications LDLA 
	  on      TA.LocalDrivingLicenseApplicationID=LDLA.LocalDrivingLicenseApplicationID
	  join Applications A
	  on LDLA.ApplicationID=A.ApplicationID

	  where A.ApplicationID=110;



	
		--/////////////////////////////*******************///////////////////////////////////////
	
	SELECT 
    TA.TestAppointmentID AS [Appointment ID],
    TA.AppointmentDate,
    TA.PaidFees,
    TA.IsLocked
FROM 
    Applications A
JOIN 
    LocalDrivingLicenseApplications LDLA 
    ON A.ApplicationID = LDLA.ApplicationID
JOIN 
    TestAppointments TA 
    ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
WHERE 
    A.ApplicationID = 1127;


		


			 SELECT 
                         TA.TestAppointmentID AS [Appointment ID],
                         TA.AppointmentDate,
                         TA.PaidFees,
                         TA.IsLocked
                     FROM 
                         Applications A
                     JOIN 
                         LocalDrivingLicenseApplications LDLA 
                         ON A.ApplicationID = LDLA.ApplicationID
                     JOIN 
                         TestAppointments TA 
                         ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                     WHERE 
                         A.ApplicationID =110


SELECT top 1 
    TestAppointmentID,
    LocalDrivingLicenseApplicationID,
    AppointmentDate,
    TestTypeID,
    IsLocked,
    RetakeTestApplicationID
FROM 
    TestAppointments
WHERE 
    LocalDrivingLicenseApplicationID =37;

	--/////////////////////////////*******************///////////////////////////////////////

	select  * from Applications

	


UPDATE TestAppointments
SET LocalDrivingLicenseApplicationID =50
WHERE TestAppointmentID = 42;

select IsLocked from TestAppointments
where TestAppointmentID=108;


DELETE FROM Applications
WHERE ApplicationID BETWEEN 1127 AND 1142;




	
	-----------------***************------------------------------
SELECT 
    Applications.ApplicantPersonID, 
    People.NationalNo, 
    People.PersonID, 
    LicenseClasses.LicenseClassID, 
    LocalDrivingLicenseApplications.ApplicationID
FROM Applications
INNER JOIN LocalDrivingLicenseApplications 
    ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
INNER JOIN LicenseClasses 
    ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
INNER JOIN People 
    ON Applications.ApplicantPersonID = People.PersonID
WHERE People.NationalNo ='N1'
  AND LocalDrivingLicenseApplications.LicenseClassID = 1


		-----------------***************------------------------------


--**------------------------**
 --  ÊÚØíá ÇáÞíæÏ Ýí ÇáÌÏæá 

ALTER TABLE ÇÓã_ÇáÌÏæá NOCHECK CONSTRAINT ALL;

-- áÅÚÇÏÉ ÊÝÚíáåÇ
ALTER TABLE ÇÓã_ÇáÌÏæá CHECK CONSTRAINT ALL;



--**------------------------**
ALTER TABLE Applications NOCHECK CONSTRAINT ALL;
ALTER TABLE Users NOCHECK CONSTRAINT ALL;
ALTER TABLE People NOCHECK CONSTRAINT ALL;
ALTER TABLE ApplicationTypes NOCHECK CONSTRAINT ALL;
ALTER TABLE LocalDrivingLicenseApplications NOCHECK CONSTRAINT ALL;
ALTER TABLE TestAppointments NOCHECK CONSTRAINT ALL;


-- áÅÚÇÏÉ ÊÝÚíáåÇ
ALTER TABLE Applications CHECK CONSTRAINT ALL;
ALTER TABLE Users CHECK CONSTRAINT ALL;
ALTER TABLE People CHECK CONSTRAINT ALL;
ALTER TABLE ApplicationTypes CHECK CONSTRAINT ALL;
ALTER TABLE LocalDrivingLicenseApplications CHECK CONSTRAINT ALL;
ALTER TABLE TestAppointments CHECK CONSTRAINT ALL;


select * from TestAppointments;

select  IsLocked from TestAppointments
          where LocalDrivingLicenseApplicationID=36 and TestTypeID=1



		    SELECT COUNT(*) 
        FROM TestAppointments TA
        JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
        WHERE 
            TA.LocalDrivingLicenseApplicationID = ldla.LocalDrivingLicenseApplicationID
            AND T.TestResult = 1
         ) AS [PassedTests]



		SELECT * FROM Applications WHERE ApplicationID = 1039;

		restore database DVLD2
		from disk='D:\Abu hadhoud\abu hadhoud\Course  19  Full Real Project\DVLD2.bak';

		------------------------****************************----------------------------------
		------------------------****************************----------------------------------

		------------------------****************************----------------------------------
SELECT 
    Licenses.LicenseID AS [Lic ID],
    Licenses.ApplicationID AS [App ID],
    LicenseClasses.ClassName AS [Class Name],
    Licenses.IssueDate,
    Licenses.ExpirationDate,
    Licenses.IsActive,

    -- ÈÇÞí ÇáÃÚãÏÉ ÇáÅÖÇÝíÉ (ááÇÓÊÎÏÇãÇÊ ÇáÃÎÑì Ãæ ÇáÚÑÖ Ýí ÇáÊÝÇÕíá):
    People.PersonID,
    People.NationalNo,
    People.FirstName,
    People.SecondName,
    People.ThirdName,
    People.LastName,
    People.Gendor,
    People.DateOfBirth,
    People.ImagePath,
    
    Licenses.DriverID,
    Licenses.Notes,
    Licenses.IssueReason,

    LicenseClasses.LicenseClassID,
    Drivers.DriverID AS Expr1

FROM Licenses
INNER JOIN LicenseClasses 
    ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
INNER JOIN Applications 
    ON Licenses.ApplicationID = Applications.ApplicationID
INNER JOIN People 
    ON Applications.ApplicantPersonID = People.PersonID
INNER JOIN Drivers 
    ON Licenses.DriverID = Drivers.DriverID 
    AND People.PersonID = Drivers.PersonID
	where LicenseID=23;
                       

		------------------------****************************----------------------------------

SELECT 
    Drivers.DriverID,
    Drivers.PersonID,
    People.NationalNo,
    (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS FullName,
    Licenses.IssueDate AS [Date],
    Licenses.IsActive AS ActiveLicense
FROM 
    Drivers
INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID
INNER JOIN People ON Drivers.PersonID = People.PersonID





		------------------------****************************----------------------------------
		
 SELECT LocalDrivingLicenseApplicationID FROM LocalDrivingLicenseApplications
                             where ApplicationID=113; 
		  
    select * from Applications;

	select * from LocalDrivingLicenseApplications;


    select * from ApplicationTypes;

  	select  * from Users;
		  select * from Applications;

DELETE FROM Applications
WHERE ApplicationID =1122;

SELECT * FROM Applications WHERE ApplicationID > 115;



select TestTypeFees from TestTypes
where TestTypeID=2;
select * from LicenseClasses;

DELETE FROM Licenses
WHERE LicenseID=26;


select InternationalLicenseID as [Int.LicenseID] ,
ApplicationID  as [Application ID] ,
DriverID as [Driver ID],
 IssuedUsingLocalLicenseID as [L.License ID],
 IssueDate as [Issue Date],
 ExpirationDate as [Expiration Date],
 IsActive as [Is Active] 
 from InternationalLicenses


 
select * from ApplicationTypes;

SELECT * FROM Applications




select * from LocalDrivingLicenseApplications;

select * from TestTypes;

select  * from People;

select * from TestTypes;


select * from TestAppointments;


select * from DetainedLicenses
select * from Drivers;
select * from Licenses;
select * from InternationalLicenses;

select * from Tests;
SELECT * FROM TestAppointments
SELECT * FROM LocalDrivingLicenseApplications
------------------------****************************----------------------------------
SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID =1) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = LicenseClassID)
                        AND ( TestAppointments.TestTypeID=TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC

				------------------------****************************----------------------------------

SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;


						------------------------****************************----------------------------------
  SELECT top 1 TestResult
                    FROM LocalDrivingLicenseApplications 
					INNER JOIN
                         TestAppointments ON
						 LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
				    INNER JOIN
                         Tests ON
						 TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                    WHERE
                    (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = 41)
                    AND(TestAppointments.TestTypeID = TestTypeID)
                    ORDER BY TestAppointments.TestAppointmentID desc

------------------------****************************----------------------------------
  SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = LicenseClass 
                              AND Drivers.PersonID = PersonID
                              And IsActive=1
 ------------------------****************************----------------------------------

 SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              order by ApplicationDate Desc
			
SELECT        dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, dbo.LicenseClasses.ClassName, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') 
                         + ' ' + dbo.People.LastName AS FullName, dbo.Applications.ApplicationDate,
                             (SELECT        COUNT(dbo.TestAppointments.TestTypeID) AS PassedTestCount
                                FROM            dbo.Tests INNER JOIN
                                                         dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                                WHERE        (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTestCount, 
                         CASE
						 WHEN Applications.ApplicationStatus = 1 THEN 'New'
						 WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled' 
						 WHEN Applications.ApplicationStatus = 3 THEN 'Completed' 
						 END AS Status
FROM            dbo.LocalDrivingLicenseApplications INNER JOIN
                         dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
                         dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
                         dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID



------------------------****************************----------------------------------

						  SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications 
							INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
						    INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = 41) 
                            AND(TestAppointments.TestTypeID = TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc

------------------------****************************----------------------------------
SELECT 
            InternationalLicenses.InternationalLicenseID,
            InternationalLicenses.DriverID,
            InternationalLicenses.ApplicationID,
            InternationalLicenses.IssuedUsingLocalLicenseID,
            InternationalLicenses.IssueDate,
            InternationalLicenses.ExpirationDate,
            InternationalLicenses.IsActive,

            Licenses.LicenseID,

            People.PersonID,
            People.NationalNo,
            People.FirstName,
            People.SecondName,
            People.ThirdName,
            People.LastName,
            People.DateOfBirth,
            People.Gendor

        FROM Licenses
        INNER JOIN InternationalLicenses 
            ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
        INNER JOIN Drivers 
            ON Licenses.DriverID = Drivers.DriverID 
            AND InternationalLicenses.DriverID = Drivers.DriverID
        INNER JOIN People 
            ON Drivers.PersonID = People.PersonID
        WHERE Licenses.LicenseID = 24

------------------------****************************----------------------------------

   SELECT 
             a.ApplicationID,
             a.ApplicationDate,
             a.ApplicationStatus,
             a.ApplicationTypeID AS AppTypeID,
             a.LastStatusDate,
             a.PaidFees,
             a.CreatedByUserID,
          
             at.ApplicationTypeTitle,
             at.ApplicationTypeID AS TypeID,
                   
              ldla.LocalDrivingLicenseApplicationID,
              ldla.ApplicationID AS LDLA_AppID,
              ldla.LicenseClassID AS LDLA_ClassID,
          
              lc.ClassName,
              lc.LicenseClassID,
          
              p.PersonID,
              p.FirstName,
              p.SecondName,
              p.ThirdName,
              p.LastName,
          
              u.UserID,
              u.UserName,

            (
        SELECT COUNT(*) 
        FROM TestAppointments TA
        JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
        WHERE 
            TA.LocalDrivingLicenseApplicationID = ldla.LocalDrivingLicenseApplicationID
            AND T.TestResult = 1
         ) AS [PassedTests]

          FROM Applications a
          INNER JOIN ApplicationTypes at ON a.ApplicationTypeID = at.ApplicationTypeID
          INNER JOIN LocalDrivingLicenseApplications ldla ON a.ApplicationID = ldla.ApplicationID
          INNER JOIN LicenseClasses lc ON ldla.LicenseClassID = lc.LicenseClassID
          INNER JOIN People p ON a.ApplicantPersonID = p.PersonID
          JOIN Users u ON a.CreatedByUserID = u.UserID
          
          
          WHERE ldla.LocalDrivingLicenseApplicationID = 36

		  --------------------------------------------------------
SELECT 
    DL.DetainID,
    DL.LicenseID,
    DL.DetainDate,
    DL.FineFees,
    DL.IsReleased,
    DL.ReleaseDate,
    DL.ReleaseApplicationID,
    P.PersonID,
    P.NationalNo,
    P.FirstName,
    P.SecondName,
    P.ThirdName,
    P.LastName
FROM DetainedLicenses DL
INNER JOIN Licenses L ON DL.LicenseID = L.LicenseID
INNER JOIN People P ON L.PersonID = P.PersonID
WHERE DL.LicenseID = 25;


						 select * from DetainedLicenses

						

		SELECT ActiveApplicationID=Applications.ApplicationID  
                      From
                      Applications INNER JOIN
                      LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                      WHERE ApplicantPersonID = ApplicantPersonID 
                      and ApplicationTypeID=ApplicationTypeID 
		and LocalDrivingLicenseApplications.LicenseClassID = LicenseClassID
                      and ApplicationStatus=1


					   sp_help Licenses;


					 