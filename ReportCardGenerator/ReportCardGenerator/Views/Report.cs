using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCardGenerator.Beans;
using ReportCardGenerator.Controller;
using ReportCardGenerator.DataSet;
using ReportCardGenerator.Data;
using ReportCardGenerator.Interfaces;
using ReportCardGenerator.Reports;


namespace ReportCardGenerator.Views
{
    public partial class StudReportCard : Form
    {
        ProgressBar PBar = new ProgressBar();
        IStudentController controller = FrontController.getInstance().getStudentController();
        IGradeController gradeController = new GradeController();
        IHonorController honorController = new HonorController();

        DataSet2 ReportSet = new DataSet2();
        public String StudntID = "none";
        public String GradeSec = "";
        public static String source = "";
        public static String SY = "";
        public static String T1 = "";
        public static String T2 = "";
        public static String T3 = "";
        public static RPdata DS = new RPdata();
        ReportCardDataset RCDataSet = new ReportCardDataset();
        int period = 0;
        Grade1 crys = new Grade1();
        GradeBook crystal = new GradeBook();
        Upper4 upper4 = new Upper4();
        Upper3ILC upper3ILC = new Upper3ILC();
        Upper3 upper3 = new Upper3();
        Upper1 upper1 = new Upper1();
        Upper1ILC upper1ILC = new Upper1ILC();
        Grade7ILC grade7ILC = new Grade7ILC();
        Grade6 grade6 = new Grade6();
        Grade6ILC grade6ILC = new Grade6ILC();
        Grade3 grade3 = new Grade3();
        Grade3ILC grade3ILC = new Grade3ILC();
        Grade2 grade2 = new Grade2();

       
        //#region Finals variables
        //double math1 = 0;
        //double math2 = 0;
        //double math3 = 0;
        //double math4 = 0;

        //double science1 = 0;
        //double science2 = 0;
        //double science3 = 0;
        //double science4 = 0;

        //double read1 = 0;
        //double read2 = 0;
        //double read3 = 0;
        //double read4 = 0;

        //double lang1 = 0;
        //double lang2 = 0;
        //double lang3 = 0;
        //double lang4 = 0;

        //double hist1 = 0;
        //double hist2 = 0;
        //double hist3 = 0;
        //double hist4 = 0;

        //double lead1 = 0;
        //double lead2 = 0;
        //double lead3 = 0;
        //double lead4 = 0;

        //double fil1 = 0;
        //double fil2 = 0;
        //double fil3 = 0;
        //double fil4 = 0;

        //double spfl1 = 0;
        //double spfl2 = 0;
        //double spfl3 = 0;
        //double spfl4 = 0;


        //double comp1 = 0;
        //double comp2 = 0;
        //double comp3 = 0;
        //double comp4 = 0;

        //double PE1 = 0;
        //double PE2 = 0;
        //double PE3 = 0;
        //double PE4 = 0;

        //double Art1 = 0;
        //double Art2 = 0;
        //double Art3 = 0;
        //double Art4 = 0;

        //double Music1 = 0;
        //double Music2 = 0;
        //double Music3 = 0;
        //double Music4 = 0;

        //double Forex1 = 0;
        //double Forex2 = 0;
        //double Forex3 = 0;
        //double Forex4 = 0;

        //double cocur1 = 0;
        //double cocur2 = 0;
        //double cocur3 = 0;
        //double cocur4 = 0;

        //double deport1 = 0;
        //double deport2 = 0;
        //double deport3 = 0;
        //double deport4 = 0;

        //double reli1 = 0;
        //double reli2 = 0;
        //double reli3 = 0;
        //double reli4 = 0;

        //double life1 = 0;
        //double life2 = 0;
        //double life3 = 0;
        //double life4 = 0;

        //double conduct1 = 0;
        //double conduct2 = 0;
        //double conduct3 = 0;
        //double conduct4 = 0;

        //double rela1 = 0;
        //double rela2 = 0;
        //double rela3 = 0;
        //double rela4 = 0;

        //double mape1 = 0;
        //double mape2 = 0;
        //double mape3 = 0;
        //double mape4 = 0;

        //double eng1 = 0;
        //double eng2 = 0;
        //double eng3 = 0;
        //double eng4 = 0;

        //double slge1 = 0;
        //double slge2 = 0;
        //double slge3 = 0;
        //double slge4 = 0;

        //double HE1 = 0;
        //double HE2 = 0;
        //double HE3 = 0;
        //double HE4 = 0;

        //double CAS1 = 0;
        //double CAS2 = 0;
        //double CAS3 = 0;
        //double CAS4 = 0;

        //double BTA1 = 0;
        //double BTA2 = 0;
        //double BTA3 = 0;
        //double BTA4 = 0;

        //double entrep1 = 0;
        //double entrep2 = 0;
        //double entrep3 = 0;
        //double entrep4 = 0;

        //double shop1 = 0;
        //double shop2 = 0;
        //double shop3 = 0;
        //double shop4 = 0;

        //double homeEco1 = 0;
        //double homeEco2 = 0;
        //double homeEco3 = 0;
        //double homeEco4 = 0;

        //double phys1 = 0;
        //double phys2 = 0;
        //double phys3 = 0;
        //double phys4 = 0;
//#endregion
        #region Skill Finals Variables
        double frsta1 = 0;
        double frsta2 = 0;
        double frsta3 = 0;

        double seca1 = 0;
        double seca2 = 0;
        double seca3 = 0;

        double thrda1 = 0;
        double thrda2 = 0;
        double thrda3 = 0;

        double frtha1 = 0;
        double frtha2 = 0;
        double frtha3 = 0;

        double fftha1 = 0;
        double fftha2 = 0;
        double fftha3 = 0;

        double sxtha1 = 0;
        double sxtha2 = 0;
        double sxtha3 = 0;

        double svtha1 = 0;
        double svtha2 = 0;
        double svtha3 = 0;

        double eitha1 = 0;
        double eitha2 = 0;
        double eitha3 = 0;

        double nntha1 = 0;
        double nntha2 = 0;
        double nntha3 = 0;

        double tntha1 = 0;
        double tntha2 = 0;
        double tntha3 = 0;

        double frsthb1 = 0;
        double frsthb2 = 0;
        double frsthb3 = 0;

        double secb1 = 0;
        double secb2 = 0;
        double secb3 = 0;

        double thrdb1 = 0;
        double thrdb2 = 0;
        double thrdb3 = 0;

        double frthb1 = 0;
        double frthb2 = 0;
        double frthb3 = 0;

        double frsthc1 = 0;
        double frsthc2 = 0;
        double frsthc3 = 0;

        double secc1 = 0;
        double secc2 = 0;
        double secc3 = 0;

        double thrdc1 = 0;
        double thrdc2 = 0;
        double thrdc3 = 0;

        double frthc1 = 0;
        double frthc2 = 0;
        double frthc3 = 0;

        double frsthd1 = 0;
        double frsthd2 = 0;
        double frsthd3 = 0;

        double secd1 = 0;
        double secd2 = 0;
        double secd3 = 0;

        double thrdd1 = 0;
        double thrdd2 = 0;
        double thrdd3 = 0;

        double frthd1 = 0;
        double frthd2 = 0;
        double frthd3 = 0;

        double ffthd1 = 0;
        double ffthd2 = 0;
        double ffthd3 = 0;

        double sxthd1 = 0;
        double sxthd2 = 0;
        double sxthd3 = 0;

        double frsthe1 = 0;
        double frsthe2 = 0;
        double frsthe3 = 0;

        double sece1 = 0;
        double sece2 = 0;
        double sece3 = 0;

        double thrde1 = 0;
        double thrde2 = 0;
        double thrde3 = 0;

        #endregion
        public StudReportCard()
        {
            InitializeComponent();
        }

        private void GradeBook1_InitReport(object sender, EventArgs e)
        {

        }

        private void ReportCardTaks_Load(object sender, EventArgs e)
        {
           
            foreach (Student s in State.getInstance().Students)
            {
                //StudentList.Items.Add(s.StudentID);
            }
            this.Text = GradeSec + " " + "Report Card";
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            SubjectUnit.loadUnit();
            PBar.Show();
            this.Enabled = false;
            gradeloads();
            this.Enabled = true;
            PBar.Hide();
            crystalReportViewer1.Refresh();
            //grade6ILC.SetDataSource(DS);
            //crystalReportViewer1.ReportSource = grade6ILC;
            DataView myview = new DataView(DS.SkillFinal);
            dataGridView1.DataSource = myview;
           
        }

        private void gradeloads()
        {
            //try
            //{
                UserInputData inputted = new UserInputData();
                inputted.SY = SY;
                inputted.T1 = T1;
                inputted.T2 = T2;
                inputted.T3 = T3;
                foreach (Student Stud in controller.getAllStudents())
                {
                    //Loading Student and Student Details to Hashtable
                    DataRow studCard = DS.StudentCardTable.NewRow();
                    studCard["StudentId"] = Stud.StudentID;
                    studCard["FirstName"] = Stud.FirstName;
                    studCard["LastName"] = Stud.LastName;
                    studCard["Grade"] = Stud.Level;
                    studCard["Section"] = Stud.Section;
                    studCard["Adviser"] = Stud.Adviser;
                    studCard["SY"] = inputted.SY;
                    studCard["T1SchooDays"] = inputted.T1;
                    studCard["T2SchooDays"] = inputted.T2;
                    studCard["T3SchooDays"] = inputted.T3;
                    DS.StudentCardTable.Rows.Add(studCard);

                    GradeSec = Stud.Level + "-" + Stud.Section;
                    foreach (Period tempPeriod in Stud.RptCard.Periods)
                    {
                        gradeController.loadStudentDetails(tempPeriod, Stud, DS);
                        switch (tempPeriod.PeriodID)
                        {
                            case 1: DataRow term1Drow = DS.Gradeterm1.NewRow();
                                DS.Gradeterm1.Rows.Add(gradeController.loadGrade(tempPeriod,Stud, term1Drow, FinalComp.ListGradeTerm1));
                                
                                DataRow SkillTerm1Row = DS.Skillterm1.NewRow();
                                DS.Skillterm1.Rows.Add(gradeController.loadSkills(tempPeriod, Stud.StudentID, SkillTerm1Row, FinalComp.ListSkillTerm1));

                                honorController.ComputeTermsHonors(DS.HonorsTerm1, Stud.StudentID, Stud.Level, FinalComp.ListGradeTerm1, tempPeriod.PeriodID);
                                honorController.ComputeTermsFormat(DS.HonorsFormat, tempPeriod.PeriodID, Stud.Level,Stud.StudentID);
                                break;
                            case 2: DataRow term2Drow = DS.Gradeterm2.NewRow();
                                DS.Gradeterm2.Rows.Add(gradeController.loadGrade(tempPeriod, Stud, term2Drow, FinalComp.ListGradeTerm2));

                                DataRow SkillTerm2Row = DS.Skillterm2.NewRow();
                                DS.Skillterm2.Rows.Add(gradeController.loadSkills(tempPeriod, Stud.StudentID, SkillTerm2Row, FinalComp.ListSkillTerm2));
                                

                                honorController.ComputeTermsHonors(DS.HonorsTerm2, Stud.StudentID, Stud.Level, FinalComp.ListGradeTerm2, tempPeriod.PeriodID);
                                honorController.ComputeTermsFormat(DS.HonorsFormat2, tempPeriod.PeriodID, Stud.Level, Stud.StudentID);
                                break;
                            case 3: DataRow term3Drow = DS.Gradeterm3.NewRow();
                                DS.Gradeterm3.Rows.Add(gradeController.loadGrade(tempPeriod, Stud, term3Drow, FinalComp.ListGradeTerm3));

                                DataRow SkillTerm3Row = DS.Skillterm3.NewRow();
                                DS.Skillterm3.Rows.Add(gradeController.loadSkills(tempPeriod, Stud.StudentID, SkillTerm3Row, FinalComp.ListSkillTerm3));
                                honorController.ComputeTermsHonors(DS.HonorsTerm3, Stud.StudentID, Stud.Level, FinalComp.ListGradeTerm3, tempPeriod.PeriodID);

                                DataRow FinalCompRow = DS.GradeFinal.NewRow();
                                DS.GradeFinal.Rows.Add(gradeController.FinalComputation(Stud.StudentID, tempPeriod.PeriodID, FinalCompRow));

                                DataRow SkillFinalCompRow = DS.SkillFinal.NewRow();
                                DS.SkillFinal.Rows.Add(gradeController.SkillsFinalComputation(Stud.StudentID,SkillFinalCompRow));
                                
                                honorController.ComputeTermsHonors(DS.HonorsFinals, Stud.StudentID, Stud.Level, FinalComp.ListGradeFinal, tempPeriod.PeriodID);
                                honorController.ComputeTermsFormat(DS.HonorsFormat3, tempPeriod.PeriodID, Stud.Level, Stud.StudentID);

                                DataRow actionTakenRow = DS.ActionTaken.NewRow();
                                DS.ActionTaken.Rows.Add(ActionTakenUnitsEarned.ActionTaken(actionTakenRow, Stud.StudentID, tempPeriod.PeriodID, Stud.Level));
                                if (Stud.RptCard.Periods.Count.Equals(3))
                                {
                                    DataRow unitsEarnedRow = DS.UnitsEarned.NewRow();
                                    DS.UnitsEarned.Rows.Add(ActionTakenUnitsEarned.UnitsEarned(unitsEarnedRow, Stud.Level, tempPeriod, Stud));
                                }
                                DataRow finalAttendance = DS.TermSR.NewRow();
                                DS.TermSR.Rows.Add(gradeController.getAttendanceFinalComp(Stud.StudentID,finalAttendance));
                                break;
                            case 4: DataRow term4Drow = DS.GradetermSR.NewRow();
                                DS.GradetermSR.Rows.Add(gradeController.loadGrade(tempPeriod, Stud, term4Drow, FinalComp.ListGradeSR));
                                UpdateFinalGrade(DS.GradeFinal, DS.ActionTaken, Stud.StudentID, tempPeriod.PeriodID);
                                ActionTakenUnitsEarned.UpdateActionTaken(DS.ActionTaken, Stud);
                                if (Stud.RptCard.Periods.Contains(tempPeriod))
                                {
                                    DataRow unitsEarnedRow2 = DS.UnitsEarned.NewRow();
                                    DS.UnitsEarned.Rows.Add(ActionTakenUnitsEarned.UnitsEarned(unitsEarnedRow2, Stud.Level, tempPeriod, Stud));
                                }
                                break;
                        }
                        if (Stud.RptCard.Periods.Count.Equals(3))
                        {
                        }
                        else
                        {
                          }
                        
                    } 
                }
                ReportSelector();
                crystalReportViewer1.Refresh();
            //}
            //catch(Exception er)
            //{
            //    //MessageBox.Show(er.Message);
            //}
        }
        #region Hidden codes for future use
        /*
        private void addToList(Student Stud, Double grade, String SubjectId, List<FinalComp> ListGrade)
        {
            FinalComp finalComp = new FinalComp();
            finalComp.StudId = Stud.StudentID;
            finalComp.Grade = grade;
            finalComp.SubjectId = SubjectId;
            ListGrade.Add(finalComp);
        }
       
        private DataRow loadGrade(Period tempPeriod, Student Stud, DataRow grow, List<FinalComp> ListGrade)
        {
            #region loading of grades to datarow from List
            //Math
            grow["Math"] = isNotNull("MATH", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("MATH", tempPeriod, Stud), "MATH", ListGrade);
            //Science
            grow["Science"] = isNotNull("SCIE", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("SCIE", tempPeriod, Stud), "SCIE", ListGrade);

            //if (source == "Grade 1" || source == "Grade 2")
            //{
            //    grow["English"] = isNotNull("READ", tempPeriod,Stud);
            //    rela1 = isNotNullNumericGrade("READ", tempPeriod,Stud);
            //}


            //Reading
            grow["Reading"] = isNotNull("READ", tempPeriod);
            read1 = isNotNullNumericGrade("READ", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("READ", tempPeriod, Stud), "READ", ListGrade);


            //Language
            grow["Language"] = isNotNull("LANG", tempPeriod);
            lang1 = isNotNullNumericGrade("LANG", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("LANG", tempPeriod, Stud), "LANG", ListGrade);

            if (source.Equals("Grade 1") || source.Equals("Grade 2") || source.Equals("Grade 3-ILC") || source.Equals("Grade 4-ILC") || source.Equals("Grade 5-ILC") || source.Equals("Grade 6-ILC") || source.Equals("Grade 7-ILC") || source.Equals("Upper School I") || source.Equals("Upper School I-ILC") || source.Equals("Upper School II") || source.Equals("Upper School II-ILC") || source.Equals("Upper School III") || source.Equals("Upper School III-ILC") || source.Equals("Upper School IV") || source.Equals("Upper School IV-ILC"))
            {
                grow["English"] = isNotNull("ENGL", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("ENGL", tempPeriod, Stud), "ENGL", ListGrade);

            }
            else
            {
                if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("LANG"); }) != null)
                {
                    rela1 = lang1;
                    grow["English"] = checker(Math.Round(rela1, 2),tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
                else if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("READ"); }) != null)
                {
                    rela1 = read1;
                    grow["English"] = checker(Math.Round(rela1, 2), tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
                else
                {
                    rela1 = (read1 + lang1) / 2;
                    grow["English"] = checker(Math.Round(rela1, 2), tempPeriod.PeriodID);
                    addToList(Stud, rela1, "ENGL", ListGrade);
                }
            }
               
           
            //English Upper School 4
            //if (source == "Upper School IV")
            //{
            //    grow["English"] = isNotNull("ENGL", tempPeriod,Stud);
            //    rela1 = isNotNullNumericGrade("ENGL", tempPeriod,Stud);
            //}
            //English Grades 1-6
            //if (source == "Grade 7" || source == "Grade 6" || source == "Grade 5" || source == "Grade 4" || source == "Grade 3")
            //{

            //}
            //History
            grow["History"] = isNotNull("HIST", tempPeriod);
            hist1 = isNotNullNumericGrade("HIST", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("HIST", tempPeriod, Stud), "HIST", ListGrade);

            //Leadership
            grow["Leadership"] = isNotNull("LEAD", tempPeriod);
            lead1 = isNotNullNumericGrade("LEAD", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("LEAD", tempPeriod, Stud), "LEAD", ListGrade);

            if (isOffered("LEAD", tempPeriod, Stud) && !isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = 0;
                grow["SLGE"] = isNotNull("LEAD", tempPeriod);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }
            if (!isOffered("LEAD", tempPeriod, Stud) && isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = 0;
                grow["SLGE"] = isNotNull("HIST", tempPeriod);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }
            //SLGE
            if (isOffered("LEAD", tempPeriod, Stud) && isOffered("HIST", tempPeriod, Stud))
            {
                slge1 = (hist1 + lead1) / 2;
                grow["SLGE"] = checker(Math.Round(slge1), tempPeriod.PeriodID);
                addToList(Stud, slge1, "SLGE", ListGrade);
            }

            //Computer Education
            grow["Computer"] = isNotNull("COMP", tempPeriod);
            comp1 = isNotNullNumericGrade("COMP", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COMP", tempPeriod, Stud), "COMP", ListGrade);
            //SHOP
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SHOP"); }) != null)
            {
                grow["Shop"] = isNotNull("SHOP", tempPeriod);
                shop1 = isNotNullNumericGrade("SHOP", tempPeriod, Stud);
                addToList(Stud, isNotNullNumericGrade("SHOP", tempPeriod, Stud), "SHOP", ListGrade);
            }
          
            //Home Economics
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("HOME"); }) != null)
            {
                grow["HomeEco"] = isNotNull("HOME", tempPeriod);
                homeEco1 = isNotNullNumericGrade("HOME", tempPeriod, Stud);
                addToList(Stud, isNotNullNumericGrade("HOME", tempPeriod, Stud), "HOME", ListGrade);
            }
            else if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SHOP"); }) != null)
            {
                grow["HomeEco"] = isNotNull("SHOP", tempPeriod);
                shop1 = isNotNullNumericGrade("SHOP", tempPeriod, Stud);
                addToList(Stud, isNotNullNumericGrade("SHOP", tempPeriod, Stud), "HOME", ListGrade);
            }
            //Economics and Investments
            grow["EntrepAcc"] = isNotNull("ECON", tempPeriod);
            entrep1 = isNotNullNumericGrade("ECON", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("ECON", tempPeriod, Stud), "ECON", ListGrade);

            if (source != "Upper School III-ILC" || source != "Upper School IV-ILC" || source != "Upper School II-ILC" || source != "Upper School I-ILC")
            {
                if (isOffered("ECON", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = entrep1;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = comp1;
                }
                else if (isOffered("HOME", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = homeEco1;
                }
                else if (isOffered("ECON", tempPeriod, Stud) && isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = (entrep1 + comp1) / 2;
                }
                else if (isOffered("ECON", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (entrep1 + homeEco1) / 2;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (comp1 + homeEco1) / 2;
                }
                else if (!isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud) && !isOffered("ECON", tempPeriod, Stud))
                {
                    BTA1 = 0;
                }
            }
            else
            //if (source == "Upper School III-ILC" || source == "Upper School IV-ILC" || source == "Upper School II-ILC" || source == "Upper School I-ILC")
            {
                if (isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = comp1;
                }
                else if (isOffered("HOME", tempPeriod, Stud) && !isOffered("COMP", tempPeriod, Stud))
                {
                    BTA1 = homeEco1;
                }
                else if (isOffered("COMP", tempPeriod, Stud) && isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = (comp1 + homeEco1) / 2;
                }
                else if (!isOffered("COMP", tempPeriod, Stud) && !isOffered("HOME", tempPeriod, Stud))
                {
                    BTA1 = 0;
                }
                //grow["BTA"] = checker(BTA1);
                //addToList(Stud, BTA1, "BTA", ListGrade);

                //If CAS and Art is offered on Term 1
                //if (isOffered("COIN", tempPeriod) && isOffered("ART", tempPeriod))
                //{ mape1 = (PE1 + Art1 + cocur1) / 3; }

                ////If CAS is offered and Art is not
                //if (isOffered("COIN", tempPeriod))
                //{ mape1 = (PE1 + cocur1) / 2; }

                ////If ART is offered and CAS is not
                //if (isOffered("ART", tempPeriod))
                //{ mape1 = (PE1 + Art1) / 2; }
                //grow["MAPE"] = checker(mape1);
                //addToList(Stud, mape1, "MAPE", ListGrade);

            }

            grow["BTA"] = checker(BTA1, tempPeriod.PeriodID);
            addToList(Stud, BTA1, "BTA", ListGrade);
            //Filipino
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("FILI"); }) != null)
            {
                grow["Filipino"] = isNotNull("FILI", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("FILI", tempPeriod, Stud), "FILI", ListGrade);
            }
            //Special Filipino
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SPFL"); }) != null)
            {
                grow["Filipino"] = isNotNull("SPFL", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("SPFL", tempPeriod, Stud), "FILI", ListGrade);
            }

            //PE
            grow["PE"] = isNotNull("PHED", tempPeriod);
            PE1 = isNotNullNumericGrade("PHED", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("PHED", tempPeriod, Stud), "PHED", ListGrade);
            //Art
            grow["Art"] = isNotNull("ART", tempPeriod);
            Art1 = isNotNullNumericGrade("ART", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("ART", tempPeriod, Stud), "ART", ListGrade);
            //Music
            grow["Music"] = isNotNull("MUSI", tempPeriod);
            Music1 = isNotNullNumericGrade("MUSI", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("MUSI", tempPeriod, Stud), "MUSI", ListGrade);
            //MAPE 
            //If PE, Music and Art are offered
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (PE1 + Art1 + Music1) / 3;
            }
            //If Music and Art are offered
            if (!isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (Art1 + Music1) / 2;
            }
            //If PE and Music are offered
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud))
            {
                mape1 = (PE1 + Music1) / 2;
            }
            //If PE and Art are offered                      
            if (isOffered("PHED", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = (PE1 + Art1) / 2;
            }
            //If Art is offered and Mustic and PE is not   
            if (!isOffered("PHED", tempPeriod, Stud) && isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = Art1;
            }
            //If Music is offered and Art and PE is not  
            if (!isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = Music1;
            }
            //If PE is offered and Mustic and Art is not  
            if (isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = PE1;
            }
            if (!isOffered("PHED", tempPeriod, Stud) && !isOffered("ART", tempPeriod, Stud) && !isOffered("MUSI", tempPeriod, Stud))
            {
                mape1 = 0;
            }
            grow["MAPE"] = checker(Math.Round(mape1, 2), tempPeriod.PeriodID);
            addToList(Stud, mape1, "MAPE", ListGrade);
            //Co-Curricular
            grow["Co-curricular"] = isNotNull("COIN", tempPeriod);
            cocur1 = isNotNullNumericGrade("COIN", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COIN", tempPeriod, Stud), "COIN", ListGrade);

            
           
            //Homeroom Life
            grow["Life"] = isNotNull("HRLI", tempPeriod);
            life1 = isNotNullNumericGrade("HRLI", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("HRLI", tempPeriod, Stud), "HRLI", ListGrade);

            //Conduct
            grow["Conduct"] = isNotNull("COND", tempPeriod);
            conduct1 = isNotNullNumericGrade("COND", tempPeriod, Stud);
            addToList(Stud, isNotNullNumericGrade("COND", tempPeriod, Stud), "COND", ListGrade);

            
            //Religion/Values
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED1"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED1", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED1", tempPeriod, Stud), "RVED", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED2"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED2", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED2", tempPeriod, Stud), "RVED", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("RVED3"); }) != null)
            {
                grow["Religion"] = isNotNull("RVED3", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("RVED3", tempPeriod, Stud), "RVED", ListGrade);
            }
            
            //Religion for Grade 1 and Grade 2
            if (source == "Grade 1" || source == "Grade 2")
            {
                reli1 = (life1 + conduct1) / 2;
                grow["Religion"] = checker(reli1,tempPeriod.PeriodID);
                addToList(Stud, reli1, "RVED", ListGrade);
            }
            //Deportment
            grow["Deport"] = isNotNull("DEPO", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("DEPO", tempPeriod, Stud), "DEPO", ListGrade);

            //FOREX
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("CHIN"); }) != null)
            {
                grow["Forex"] = isNotNull("CHIN", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("CHIN", tempPeriod, Stud), "FOREX", ListGrade);
            }
            if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("FREN"); }) != null)
            {
                grow["Forex"] = isNotNull("FREN", tempPeriod);
                addToList(Stud, isNotNullNumericGrade("FREN", tempPeriod, Stud), "FOREX", ListGrade);
            }
            //Physics
            grow["Physics"] = isNotNull("PHYS", tempPeriod);
            addToList(Stud, isNotNullNumericGrade("PHYS", tempPeriod, Stud), "PHYS", ListGrade);

            //if (tempPeriod.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals("SCIE"); }) == null)
            //{
            //    grow["Science"] = isNotNull("PHYS", tempPeriod);
            //    addToList(Stud, isNotNullNumericGrade("PHYS", tempPeriod, Stud), "SCIE", ListGrade);
            //}
            //CAS
            //grow["Physics"] = isNotNull("PHYS", tempPeriod,Stud);
            //read1 = isNotNullNumericGrade("PHYS", tempPeriod,Stud);  

            
            //Student ID
            grow["StudentId"] = Stud.StudentID;
            #endregion 
            return grow;
        }
        
        private DataRow loadSkills(Period tempPeriod, String StudId, DataRow srow, List<FinalComp> ListSkills)
        {
            srow["a1"] = isNotNullESLR("A1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A1", tempPeriod), "A1", ListSkills);
            srow["a2"] = isNotNullESLR("A2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A2", tempPeriod), "A2", ListSkills);
            srow["a3"] = isNotNullESLR("A3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A3", tempPeriod), "A3", ListSkills);
            srow["a4"] = isNotNullESLR("A4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A4", tempPeriod), "A4", ListSkills);
            srow["a5"] = isNotNullESLR("A5", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A5", tempPeriod), "A5", ListSkills);
            srow["a6"] = isNotNullESLR("A6", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A6", tempPeriod), "A6", ListSkills);
            srow["a7"] = isNotNullESLR("A7", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A7", tempPeriod), "A7", ListSkills);
            srow["a8"] = isNotNullESLR("A8", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A8", tempPeriod), "A8", ListSkills);
            srow["a9"] = isNotNullESLR("A9", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A9", tempPeriod), "A9", ListSkills);
            srow["a10"] = isNotNullESLR("A10", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("A10", tempPeriod), "A10", ListSkills);

            srow["b1"] = isNotNullESLR("B1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B1", tempPeriod), "B1", ListSkills);
            srow["b2"] = isNotNullESLR("B2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B2", tempPeriod), "B2", ListSkills);
            srow["b3"] = isNotNullESLR("B3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B3", tempPeriod), "B3", ListSkills);
            srow["b4"] = isNotNullESLR("B4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("B4", tempPeriod), "B4", ListSkills);


            srow["c1"] = isNotNullESLR("C1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C1", tempPeriod), "C1", ListSkills);
            srow["c2"] = isNotNullESLR("C2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C2", tempPeriod), "C2", ListSkills);
            srow["c3"] = isNotNullESLR("C3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C3", tempPeriod), "C3", ListSkills);
            srow["c4"] = isNotNullESLR("C4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("C4", tempPeriod), "C4", ListSkills);

            srow["d1"] = isNotNullESLR("D1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D1", tempPeriod), "D1", ListSkills);
            srow["d2"] = isNotNullESLR("D2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D2", tempPeriod), "D2", ListSkills);
            srow["d3"] = isNotNullESLR("D3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D3", tempPeriod), "D3", ListSkills);
            srow["d4"] = isNotNullESLR("D4", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D4", tempPeriod), "D4", ListSkills);
            srow["d5"] = isNotNullESLR("D5", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D5", tempPeriod), "D5", ListSkills);
            srow["d6"] = isNotNullESLR("D6", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("D6", tempPeriod), "D6", ListSkills);

            srow["e1"] = isNotNullESLR("E1", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E1", tempPeriod), "E1", ListSkills);
            srow["e2"] = isNotNullESLR("E2", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E2", tempPeriod), "E2", ListSkills);
            srow["e3"] = isNotNullESLR("E3", tempPeriod);
            addToSkillList(StudId, isNotNullESLRNumeric("E3", tempPeriod), "E3", ListSkills);

            srow["StudentId"] = StudId;
            //SkillsFinalComputation(StudId);
            return srow;
        }
        
        private void ReportSelector()
        {
            if (source == "crystal")
            {
                //test.SetDataSource(DatasetClass.reportSet);
                //crystalReportViewer1.ReportSource = test;
                //testReport.SetDataSource(gradeController.loadReport());
                //crystalReportViewer1.ReportSource = testReport;
            }
            if (source == "Grade 1")
            {
                crys.SetDataSource(DS);
                crystalReportViewer1.ReportSource = crys;
            }
            if (source == "Grade 2")
            {
                grade2.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade2;
            }
            if (source == "Grade 3-ILC" || source == "Grade 4-ILC" || source == "Grade 5-ILC")
            {
                grade3ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade3ILC;
            }
            if (source == "Grade 3" || source == "Grade 4" || source == "Grade 5")
            {
                grade3.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade3;
            }
            if (source == "Grade 6-ILC")
            {
                grade6ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade6ILC;
            }
            if (source == "Grade 6" || source == "Grade 7")
            {
                grade6.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade6;
            }
            if (source == "Grade 7-ILC")
            {
                grade7ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade7ILC;
            }
            if (source == "Upper School I-ILC" || source == "Upper School II-ILC")
            {
                upper1ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper1ILC;
            }
            if (source == "Upper School I" || source == "Upper School II")
            {
                upper1.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper1;
            }
            if (source == "Upper School III")
            {
                upper3.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper3;
            }
            if (source == "Upper School III-ILC" || source == "Upper School IV-ILC")
            {
                upper3ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper3ILC;
            }
            if (source == "Upper School IV")
            {
                upper4.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper4;
            }
        }
        
       
        private String isNotNull(String SubjectCat, Period p)
        {
            if (p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }) != null)
            {
                String value = p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }).LetterGrade;
                return value;
            }
            else if (p.PeriodID != 4)
            { return "N/A"; }
            else { return ""; }

        }
        private Boolean isOffered(String SubjectID,Period p, Student Stud)
        {
            Period period = new Period();
            period = Stud.RptCard.Periods.Find(delegate(Period per) { return per.PeriodID.Equals(p.PeriodID); });

            if (period.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectID); }) != null)
            {
                return true;
            }
            else { return false; }
        }
        private Boolean isOnList(String SubjectId, List<FinalComp> ListFinal)
        {
            if (ListFinal.Find(delegate(FinalComp final) { return final.SubjectId.Equals(SubjectId); }) != null)
            {
                return true;
            }
            else { return false; }
        }
        
        private Double isNotNullNumericGrade(String SubjectCat, Period p, Student Stud)
        {            
            if (p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }) != null)
            {
                double value = p.Grades.Find(delegate(Grade g) { return g.SubjectID.Equals(SubjectCat); }).NumericGrade;
                return value;
            }
            else return 0;

        }
        private String isNotNullESLR(String ESLRCat, Period p)
        {
            if (p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }) != null)
            {
                String ESLRValue = p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }).LetterGrade;
                return ESLRValue;
            }
            else return "N/A";
        }
        private Double isNotNullESLRNumeric(String ESLRCat, Period p)
        {
            if (p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }) != null)
            {
                double ESLRValue = p.Skills.Find(delegate(Skill s) { return s.SkillID.Equals(ESLRCat); }).NumericGrade;
                return ESLRValue;
            }
            else return 0;
        }

       private void FinalComputation(String StudentId, int termPeriod)
        {
            #region loading of grade to final table from list
            DataRow drow = DS.GradeFinal.NewRow();
            drow["Math"] = checker(getFinal("MATH", StudentId, termPeriod), termPeriod);
            drow["Science"] = checker(getFinal("SCIE", StudentId, termPeriod), termPeriod);
            drow["Reading"] = checker(getFinal("READ", StudentId, termPeriod), termPeriod);
            drow["Language"] = checker(getFinal("LANG", StudentId, termPeriod), termPeriod);
            drow["History"] = checker(getFinal("HIST", StudentId, termPeriod), termPeriod);
            drow["Leadership"] = checker(getFinal("LEAD", StudentId, termPeriod), termPeriod);
            drow["Filipino"] = checker(getFinal("FILI", StudentId, termPeriod), termPeriod);
            drow["Computer"] = checker(getFinal("COMP", StudentId, termPeriod), termPeriod);
            drow["Music"] = checker(getFinal("MUSI", StudentId, termPeriod), termPeriod);
            drow["Art"] = checker(getFinal("ART", StudentId, termPeriod), termPeriod);
            drow["PE"] = checker(getFinal("PHED", StudentId, termPeriod), termPeriod);
            drow["Forex"] = checker(getFinal("FOREX", StudentId, termPeriod), termPeriod);
            drow["Religion"] = checker(getFinal("RVED", StudentId, termPeriod), termPeriod);
            drow["Life"] = checker(getFinal("HRLI", StudentId, termPeriod), termPeriod);
            drow["Co-curricular"] = checker(getFinal("COIN", StudentId, termPeriod), termPeriod);
            drow["Deport"] = checker(getFinal("DEPO", StudentId, termPeriod), termPeriod);
            drow["EntrepAcc"] = checker(getFinal("ECON", StudentId, termPeriod), termPeriod);
            drow["HomeEco"] = checker(getFinal("HOME", StudentId, termPeriod), termPeriod);
            drow["Shop"] = checker(getFinal("SHOP", StudentId, termPeriod), termPeriod);
            drow["SLGE"] = checker(getFinal("SLGE", StudentId, termPeriod), termPeriod);
            drow["Conduct"] = checker(getFinal("COND", StudentId, termPeriod), termPeriod);
            drow["English"] = checker(getFinal("ENGL", StudentId, termPeriod), termPeriod);
            drow["MAPE"] = checker(getFinal("MAPE", StudentId, termPeriod), termPeriod);
            drow["CAS"] = checker(getFinal("CAS", StudentId, termPeriod), termPeriod);
            drow["BTA"] = checker(getFinal("BTA", StudentId, termPeriod), termPeriod);
            drow["Physics"] = checker(getFinal("PHYS", StudentId, termPeriod), termPeriod);
            drow["StudentId"] = StudentId;
            #endregion
            DS.GradeFinal.Rows.Add(drow);

        }
         * public static String checker(double value, int termPeriod)
        {
            string variable = "";
            if (value >= 95.5 && value <= 100)
            {
                variable = "VS";
            }
            if (value >= 90.5 && value < 95.5)
            {
                variable = "S";
            }
            if (value >= 85.5 && value < 90.5)
            {
                variable = "AA";
            }
            if (value >= 79.5 && value < 85.5)
            {
                variable = "A";
            }
            if (value >= 74.5 && value < 79.5)
            {
                variable = "LA";
            }
            if (value >= 70 && value <= 74.4)
            {
                variable = "P";
            }
            if (value < 70)
            {
                variable = "INC";
            }
            if (value == 0)
            {
                if (termPeriod != 4)
                {
                    variable = "N/A";
                }
                else
                { variable = ""; }
            }
            
            return variable;
        }
         * public static Double getFinal(String SubjectId, String StudentID, int termPeriod)
        {
            try
            {
                int term1 = 0;
                int term2 = 0;
                int term3 = 0;
                FinalComp finalComp = null;
                FinalComp finalComp2 = null;
                FinalComp finalComp3 = null;
                Double finalAverage = 0;
                FinalComp final = new FinalComp();
                final.SubjectId = SubjectId;
                final.StudId = StudentID;
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm1))
                //{
                finalComp = FinalComp.ListGradeTerm1.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term1 = 1;
                        return true;
                    }
                    else { return false; }
                });
                //}
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm2))
                //{
                finalComp2 = FinalComp.ListGradeTerm2.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term2 = 1;
                        return true;

                    }
                    else { return false; }
                });
                //}
                //if (isOnList(SubjectId, FinalComp.ListGradeTerm3))
                //{
                finalComp3 = FinalComp.ListGradeTerm3.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudentID) && fcomp.SubjectId.Equals(SubjectId) && fcomp.Grade != 0)
                    {
                        term3 = 1;
                        return true;

                    }
                    else { return false; }
                });
                //}
                if (finalComp != null && finalComp2 != null && finalComp3 != null)
                {
                    final.Grade = (finalComp.Grade + finalComp2.Grade + finalComp3.Grade) / (term1 + term2 + term3);
                    FinalComp.ListGradeFinal.Add(final);
                    finalAverage = (finalComp.Grade + finalComp2.Grade + finalComp3.Grade) / (term1 + term2 + term3);

                    return finalAverage;
                }
                else
                    if (finalComp != null && finalComp2 != null && finalComp3 == null)
                    {
                        final.Grade = (finalComp.Grade + finalComp2.Grade) / (term1 + term2);
                        FinalComp.ListGradeFinal.Add(final);
                        finalAverage = (finalComp.Grade + finalComp2.Grade) / (term1 + term2);

                        return finalAverage;
                    }
                    else
                        if (finalComp != null && finalComp3 != null && finalComp2 == null)
                        {
                            final.Grade = (finalComp.Grade + finalComp3.Grade) / (term1 + term3);
                            FinalComp.ListGradeFinal.Add(final);
                            finalAverage = (finalComp.Grade + finalComp3.Grade) / (term1 + term3);

                            return finalAverage;
                        }
                        else
                            if (finalComp2 != null && finalComp3 != null && finalComp == null)
                            {
                                final.Grade = (finalComp2.Grade + finalComp3.Grade) / (term2 + term3);
                                FinalComp.ListGradeFinal.Add(final);
                                finalAverage = (finalComp2.Grade + finalComp3.Grade) / (term2 + term3);

                                return finalAverage;
                            }
                            else
                                if (finalComp != null && finalComp2 == null && finalComp3 == null)
                                {
                                    final.Grade = (finalComp.Grade) / (term1);
                                    FinalComp.ListGradeFinal.Add(final);
                                    finalAverage = (finalComp.Grade) / (term1);

                                    return finalAverage;
                                }
                                else
                                    if (finalComp == null && finalComp2 != null && finalComp3 == null)
                                    {
                                        final.Grade = (finalComp2.Grade) / (term2);
                                        FinalComp.ListGradeFinal.Add(final);
                                        finalAverage = (finalComp2.Grade) / (term2);

                                        return finalAverage;
                                    }
                                    else
                                        if (finalComp == null && finalComp2 == null && finalComp3 != null)
                                        {
                                            final.Grade = (finalComp3.Grade) / (term3);
                                            FinalComp.ListGradeFinal.Add(final);
                                            finalAverage = (finalComp3.Grade) / (term3);

                                            return finalAverage;
                                        }
                                        else
                                        {
                                            final.Grade = 0;
                                            FinalComp.ListGradeFinal.Add(final);

                                            return 0;
                                        }
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
                return 0;
            }
            finally
            {
            }
        }
         * private void addToSkillList(String StudId, Double grade, String SkillId, List<FinalComp> ListSkills)
        {
            FinalComp finalComp = new FinalComp();
            finalComp.StudId = StudId;
            finalComp.SkillGrade = grade;
            finalComp.SkillId = SkillId;
            if (finalComp.StudId != null || finalComp.StudId != "")
            {
                ListSkills.Add(finalComp);
            }
        }
        public void SkillsFinalComputation(String StudId)
        {
            #region loading of grade to final table from list
            DataRow srow = DS.SkillFinal.NewRow();
            srow["a1"] = ESLRchecker(getSkillFinal("A1", StudId));
            srow["a2"] = ESLRchecker(getSkillFinal("A2", StudId));
            srow["a3"] = ESLRchecker(getSkillFinal("A3", StudId));
            srow["a4"] = ESLRchecker(getSkillFinal("A4", StudId));
            srow["a5"] = ESLRchecker(getSkillFinal("A5", StudId));
            srow["a6"] = ESLRchecker(getSkillFinal("A6", StudId));
            srow["a7"] = ESLRchecker(getSkillFinal("A7", StudId));
            srow["a8"] = ESLRchecker(getSkillFinal("A8", StudId));
            srow["a9"] = ESLRchecker(getSkillFinal("A9", StudId));
            srow["a10"] = ESLRchecker(getSkillFinal("A10", StudId));

            srow["b1"] = ESLRchecker(getSkillFinal("B1", StudId));
            srow["b2"] = ESLRchecker(getSkillFinal("B2", StudId));
            srow["b3"] = ESLRchecker(getSkillFinal("B3", StudId));
            srow["b4"] = ESLRchecker(getSkillFinal("B4", StudId));


            srow["c1"] = ESLRchecker(getSkillFinal("C1", StudId));
            srow["c2"] = ESLRchecker(getSkillFinal("C2", StudId));
            srow["c3"] = ESLRchecker(getSkillFinal("C3", StudId));
            srow["c4"] = ESLRchecker(getSkillFinal("C4", StudId));

            srow["d1"] = ESLRchecker(getSkillFinal("D1", StudId));
            srow["d2"] = ESLRchecker(getSkillFinal("D2", StudId));
            srow["d3"] = ESLRchecker(getSkillFinal("D3", StudId));
            srow["d4"] = ESLRchecker(getSkillFinal("D4", StudId));

            //System.Windows.Forms.MessageBox.Show(getSkillFinal("D4", StudId).ToString());
            srow["d5"] = ESLRchecker(getSkillFinal("D5", StudId));
            srow["d6"] = ESLRchecker(getSkillFinal("D6", StudId));

            srow["e1"] = ESLRchecker(getSkillFinal("E1", StudId));
            srow["e2"] = ESLRchecker(getSkillFinal("E2", StudId));
            srow["e3"] = ESLRchecker(getSkillFinal("E3", StudId));
            srow["StudentId"] = StudId;
            #endregion
            DS.SkillFinal.Rows.Add(srow);

        }
        private Double getSkillFinal(String SkillId, String StudId)
        {
            //try
            //{
            int term1 = 0;
            int term2 = 0;
            int term3 = 0;
            FinalComp finalComp = null;
            FinalComp finalComp2 = null;
            FinalComp finalComp3 = null;
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm1))
            {
                finalComp = FinalComp.ListSkillTerm1.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term1 = 1;
                        return true;
                    }
                    else { return false; }
                });
            }
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm2))
            {
                finalComp2 = FinalComp.ListSkillTerm2.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term2 = 1;
                        return true;

                    }
                    else { return false; }
                });
            }
            if (isOnSkillList(SkillId, FinalComp.ListSkillTerm3))
            {
                finalComp3 = FinalComp.ListSkillTerm3.Find(delegate(FinalComp fcomp)
                {
                    if (fcomp.StudId.Equals(StudId) && fcomp.SkillId.Equals(SkillId) && fcomp.SkillGrade != 0)
                    {
                        term3 = 1;
                        return true;

                    }
                    else { return false; }
                });
            }
            if (finalComp != null && finalComp2 != null && finalComp3 != null)
            {
                return (finalComp.SkillGrade + finalComp2.SkillGrade + finalComp3.SkillGrade) / (term1 + term2 + term3);
            }
            else if (finalComp != null && finalComp2 != null && finalComp3 == null)
            {
                return (finalComp.SkillGrade + finalComp2.SkillGrade) / (term1 + term2);
            }
            else if (finalComp != null && finalComp2 == null && finalComp3 != null)
            {
                return (finalComp.SkillGrade + finalComp3.SkillGrade) / (term1 + term3);
            }
            else if (finalComp == null && finalComp2 != null && finalComp3 != null)
            {
                return (finalComp2.SkillGrade + finalComp3.SkillGrade) / (term2 + term3);
            }
            else if (finalComp != null && finalComp2 == null && finalComp3 == null)
            {
                return (finalComp.SkillGrade) / (term1);
            }
            else if (finalComp == null && finalComp2 != null && finalComp3 == null)
            {
                return (finalComp2.SkillGrade) / (term2);
            }
            else if (finalComp == null && finalComp2 == null && finalComp3 != null)
            {
                return (finalComp3.SkillGrade) / (term3);
            }
            else { return 0; }
            //}
            //catch (Exception er)
            //{
            //    //MessageBox.Show(er.Message);
            //    return 0;
            //}
            //finally
            //{
            //}
        }
        */

        #endregion
        public static String checker(double value, int termPeriod)
        {
            string variable = "";
            if (value >= 95.5 && value <= 100)
            {
                variable = "VS";
            }
            if (value >= 90.5 && value < 95.5)
            {
                variable = "S";
            }
            if (value >= 85.5 && value < 90.5)
            {
                variable = "AA";
            }
            if (value >= 79.5 && value < 85.5)
            {
                variable = "A";
            }
            if (value >= 74.5 && value < 79.5)
            {
                variable = "LA";
            }
            if (value >= 70 && value <= 74.4)
            {
                variable = "P";
            }
            if (value < 70)
            {
                variable = "INC";
            }
            if (value == 0)
            {
                if (termPeriod != 4)
                {
                    variable = "N/A";
                }
                else
                { variable = ""; }
            }

            return variable;
        }
        public static String Translate(String SubjectId)
        {
            String result = "";
            switch (SubjectId)
            {
                case "MATH": result = "Math";
                    break;
                case "SCIE": result = "Science";
                    break;
                case "READ": result = "Reading";
                    break;
                case "LANG": result = "Language";
                    break;
                case "HIST": result = "History";
                    break;
                case "LEAD": result = "Leadership";
                    break;
                case "FILI": result = "Filipino";
                    break;
                case "COMP": result = "Computer";
                    break;
                case "MUSI": result = "Music";
                    break;
                case "ART": result = "Art";
                    break;
                case "PHED": result = "PE";
                    break;
                case "FORE": result = "Forex";
                    break;
                case "FOREX": result = "Forex";
                    break;
                case "RVED": result = "Religion";
                    break;
                case "HRLI": result = "Life";
                    break;
                case "COIN": result = "Co-curricular";
                    break;
                case "DEPO": result = "Deport";
                    break;
                case "ECON": result = "EntrepAcc";
                    break;
                case "HOME": result = "HomeEco";
                    break;
                case "SHOP": result = "Shop";
                    break;
                case "SLGE": result = "SLGE";
                    break;
                case "COND": result = "Conduct";
                    break;
                case "ENGL": result = "English";
                    break;
                case "MAPE": result = "MAPE";
                    break;
                case "CAS": result = "CAS";
                    break;
                case "BTA": result = "BTA";
                    break;
                case "PHYS": result = "Physics";
                    break;
                case "SPFL": result = "SpecialFil";
                    break;
                default: result = "N/A";
                    break;
            }
            return result;
        }
        
        
        private void UpdateFinalGrade(DataTable TermFinal, DataTable ActionTaken, String StudentId, int termPeriod)
        {
            foreach (FinalComp extendedGrade in FinalComp.ListGradeSR)
            {
                if (extendedGrade.Grade >= 75)
                {
                    foreach (DataRow drow in TermFinal.Rows)
                    {
                        if (drow["StudentId"].Equals(StudentId) && StudentId.Equals(extendedGrade.StudId))
                        {
                            TermFinal.Rows[TermFinal.Rows.IndexOf(drow)][Translate(extendedGrade.SubjectId)] = checker(extendedGrade.Grade, termPeriod);
                        }
                    }
                }
            }
        }
        
        
        private void ReportSelector()
        {
            if (source == "crystal")
            {
                //test.SetDataSource(DatasetClass.reportSet);
                //crystalReportViewer1.ReportSource = test;
                //testReport.SetDataSource(gradeController.loadReport());
                //crystalReportViewer1.ReportSource = testReport;
            }
            if (source == "Grade 1")
            {
                crys.SetDataSource(DS);
                crystalReportViewer1.ReportSource = crys;
            }
            if (source == "Grade 2")
            {
                grade2.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade2;
            }
            if (source == "Grade 3-ILC" || source == "Grade 4-ILC" || source == "Grade 5-ILC")
            {
                grade3ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade3ILC;
            }
            if (source == "Grade 3" || source == "Grade 4" || source == "Grade 5")
            {
                grade3.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade3;
            }
            if (source == "Grade 6-ILC")
            {
                grade6ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade6ILC;
            }
            if (source == "Grade 6" || source == "Grade 7")
            {
                grade6.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade6;
            }
            if (source == "Grade 7-ILC")
            {
                grade7ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = grade7ILC;
            }
            if (source == "Upper School I-ILC" || source == "Upper School II-ILC")
            {
                upper1ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper1ILC;
            }
            if (source == "Upper School I" || source == "Upper School II")
            {
                upper1.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper1;
            }
            if (source == "Upper School III")
            {
                upper3.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper3;
            }
            if (source == "Upper School III-ILC" || source == "Upper School IV-ILC")
            {
                upper3ILC.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper3ILC;
            }
            if (source == "Upper School IV")
            {
                upper4.SetDataSource(DS);
                crystalReportViewer1.ReportSource = upper4;
            }
        }
        
        private String ESLRchecker(double value)
        {
            string variable = "";
            if (value >= 4.6 && value <= 5)
            {
                variable = "VS";
            }
            else
                if (value >= 3.6 && value < 4.6)
                {
                    variable = "S";
                }
                else
                    if (value >= 2.6 && value < 3.6)
                    {
                        variable = "AA";
                    }
                    else
                        if (value >= 1.6 && value < 2.6)
                        {
                            variable = "A";
                        }
                        else
                            if (value >= 1 && value < 1.6)
                            {
                                variable = "LA";
                            }
                            else
                            {
                                variable = "N/A";
                            }
            return variable;
        }
        private void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Student s = State.getInstance().Students[StudentList.SelectedIndex];
            toolTip1.Tag = s.LastName + ", " + s.FirstName;
            DS.Clear();
            StudntID = StudentList.SelectedItem.ToString();
            gradeloads();
            this.Cursor = Cursors.Default;
        }
        private Boolean isOnSkillList(String SkillId, List<FinalComp> ListFinal)
        {
            if (ListFinal.Find(delegate(FinalComp final) { return final.SkillId.Equals(SkillId); }) != null)
            {
                return true;
            }
            else { return false; }
        }
        private void StudentList_MouseHover(object sender, EventArgs e)
        {

        }
        private void HonorsBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void honorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Honors menu = new Honors();
            menu.ShowDialog();
        }

        private void depEdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void hSIVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HSIV rpt = new HSIV();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIVILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSIV_ILC rpt = new HSIV_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIIIILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSIII_ILC rpt = new HSIII_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSIII rpt = new HSIII();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIILCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HSII_ILC rpt = new HSII_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSII rpt = new HSII();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSI_ILC rpt = new HSI_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void hSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSI rpt = new HSI();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr7ILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gr7_ILC rpt = new Gr7_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G7 rpt = new G7();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr6ILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gr6_ILC rpt = new Gr6_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G6 rpt = new G6();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr5ILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gr3_ILC rpt = new Gr3_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G3 rpt = new G3();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr4ILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gr3_ILC rpt = new Gr3_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G3 rpt = new G3();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr3ILCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gr3_ILC rpt = new Gr3_ILC();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G3 rpt = new G3();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G2 rpt = new G2();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }

        private void gr1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G2 rpt = new G2();
            DepEd menu = new DepEd();
            menu.loadDepEdReport(rpt);
            menu.ShowDialog();
        }
    }
}
