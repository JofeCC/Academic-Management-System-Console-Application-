// By Joaquin Cervantes

aProfessor[] professors = new aProfessor [25];
aStudent[] students = new aStudent[100];
aCourse[] courses = new aCourse[25];

int currentProfessor = 0;
int currentStudent = 0;
int currentCourse = 0;

int index;
int answer;

// Menu for professors:
do
{
    Console.Clear();
    Console.WriteLine("Welcome to the menu for professors.\nChoose one of the following options (1-5):\n" +
        "1. Enter a new professor.\n" +
        "2. Search for a professor and see its data.\n" +
        "3. Update the data of a professor.\n" +
        "4. Delete a professor record in the system.\n" +
        "5. Display the information associated with all professors in the system.");

    do
    {
        answer = ValidateInt();
        switch (answer)
        {
            case 1:
                EnterNewProfessor();
                Console.WriteLine("------------------------------");
                Console.WriteLine($"You have created a new professor in the index ({currentProfessor - 1}) with " +
                    $"the following data:");
                DisplayProfessorInfo(currentProfessor - 1);
                Console.WriteLine($"The next index available is ({currentProfessor})");
                Console.WriteLine("------------------------------");
                break;
            case 2:
                Console.WriteLine("Enter the ID of the professor you are looking for:");
                FindProfessor();
                Console.WriteLine("------------------------------");
                break;
            case 3:
                Console.WriteLine("Enter the ID of the professor you are looking for:");
                index = FindProfessor();
                UpdateProfessor();
                break;
            case 4:
                Console.WriteLine("Enter the ID of the professor you want to delete:");
                index = FindProfessor();
                DeleteProfessor(index);
                break;
            case 5:
                DisplayProfessorsList();
                break;
            default:
                Console.WriteLine("You entered an invalid option. You have to select a number between 1 and 5. " +
                    "Please try again.");
                break;
        }
    } while (answer != 1 && answer != 2 && answer != 3 && answer != 4 && answer != 5);

    Console.WriteLine("Do you want to go to the principal menu? (y/n)");
} while (YesOrNoValidation() == "y");

// Functions for professor:
void EnterNewProfessor()
{
    if (currentProfessor == professors.Length)
    {
        Console.WriteLine("There are already 25 professors.You cannot store more professors because you don't have enough space in memory.");
    }
    else
    {
        aProfessor professor;
        Console.WriteLine("Enter the new professor's ID: ");
        professor.professorID = ValidateInt();
        Console.WriteLine("Enter the new professor's name: ");
        professor.professorName = ValidateString();
        Console.WriteLine("Enter the new professor's seniority: ");
        professor.seniority = ValidateFloat();
        (professor.disciplines, professor.counterOfDisciplines) = EnterDisciplines();
        
        professors[currentProfessor] = professor;
        currentProfessor++;
    }
}

(string[], byte) EnterDisciplines()
{
    string[] disciplines = new string[10];
    byte counter = 0;
    
        do
        {
            Console.WriteLine("Enter the new discipline to add: ");
            disciplines[counter] = ValidateString();
            counter++;
            Console.WriteLine($"You have entered {counter} discipline(s) for this professor.\nDo you want to enter another discipline? (y/n): ");

        } while (YesOrNoValidation() == "y");
        
        return (disciplines, counter);
}

int FindProfessor()
{
    int index;
    do
    {
        index = SearchProfessorByID(professors, ValidateInt());
        if (index != -1) DisplayProfessorInfo(index);
        else Console.WriteLine("Professor not found.\nPlease try again: ");
    } while (index == -1);
    return index;
}

int SearchProfessorByID(aProfessor[] arrayOfProfessors, int target)
{
    for (int i = 0; i < arrayOfProfessors.Length; i++)
    {
        if (arrayOfProfessors[i].professorID == target)
        {
            return i;
        }
    }
    return -1;
}

void DisplayProfessorInfo(int index)
{
    Console.WriteLine($"ID: {professors[index].professorID}");
    Console.WriteLine($"Name: {professors[index].professorName}");
    Console.WriteLine($"Seniority: {professors[index].seniority}");
    Console.WriteLine($"Disciplines: ");
    for (int i = 0; i < professors[index].counterOfDisciplines; i++)
    //foreach (string element in professors[index].disciplines) // I decided to not use a foreach because I don't want to print "- ." for the disciplines not entered.
    {
        Console.WriteLine($"- {professors[index].disciplines[i]}.");
        //Console.WriteLine($"- {element}."); // This was part of the foreach that I don't prefer to use.
    }
}

void UpdateProfessor()
{
    bool valid;
    do
    {
        do
        {
            Console.WriteLine("What record do you want to update for this professor (1-2):\n" +
            "1. Seniority.\n" +
            "2. Add to disciplines.");
            int ans = ValidateInt();
            valid = true;
            switch (ans)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the new senority for the selected professor: ");
                        professors[index].seniority = ValidateFloat();
                        Console.WriteLine($"The new seniority of the professor {professors[index].professorName} " +
                            $"saved in the index ({index}) is: {professors[index].seniority}.");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"There are {professors[index].counterOfDisciplines} discipline(s) " +
                            $"registered for this professor.");
                        AddDisciplines();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid choice, please try again:");
                    }
                    break;
            }
        } while (!valid);
        Console.WriteLine("Do you want to edit another datum for this professor? (y/n)");

    } while (YesOrNoValidation() == "y");
}

void AddDisciplines()
{
    if (professors[index].counterOfDisciplines == professors[index].disciplines.Length)
    {
        Console.WriteLine("There are already 10 disciplines for this professor. You cannot store more" +
            " because you don't have enough space in memory.");
        return;
    }
    else
    {
        byte counter = professors[index].counterOfDisciplines;
        do
        {
            Console.WriteLine("Enter the new discipline to add: ");
            professors[index].disciplines[counter] = ValidateString();
            counter++;
            Console.WriteLine($"You have entered {counter} discipline(s) for this professor." +
                $"\nDo you want to enter another discipline? (y/n): ");
        } while (YesOrNoValidation() == "y");
        professors[index].counterOfDisciplines = counter;
    }
}

void DeleteProfessor(int index)
{
    if (currentProfessor == 0)
    {
        Console.WriteLine("There are any professor to delete."); //This validation is unreachable in the menu because in order
        return;                                                 //to access the delete function, it is necessary to
    }                                                           //provide the ID of the professor that you want to delete.
    else
    {
        for (int i = index; i < professors.Length - 1; i++)
        {
            professors[i] = professors[i + 1];
        }
        currentProfessor--;
        Console.WriteLine("Professor deleted.");
    }
}

void DisplayProfessorsList()
{
    for (int i = 0; i < currentProfessor; i++)
    {
        Console.WriteLine($"Professor {professors[i].professorName} ID: {professors[i].professorID} Seniority: {professors[i].seniority}");
    }
    Console.WriteLine("------------------------");
}

// Q3 Functions:
int GetWeeklyHours(int courseTotalHours)
{
    do
    {
        Console.WriteLine("Enter the total hours of the course:");
        courseTotalHours = ValidateInt();
        switch (courseTotalHours)
        {
            case 90:
                return 6;
            case 75:
                return 5;
            case 60:
                return 4;
            case 45:
                return 3;
            default:
                Console.WriteLine("You have entered an invalid amount of total hours. Try again:");
                break;
        }
    } while (courseTotalHours != 90 && courseTotalHours != 75 && courseTotalHours != 60 && courseTotalHours != 45);
    return -1;
}

bool HasDiscipline(aProfessor prof, aCourse course)
{
    return prof.disciplines.Contains(course.discipline);

    //Which is equivalent to:        
    //for(int i = 0; i < prof.disciplines.Length; i++)
    //{
    //    if (course.discipline == prof.disciplines[i]) return true;
    //}
    //return false;
}

bool TeachCourse(aProfessor prof, aCourse course, int currentTeachingHours)
{
    return HasDiscipline(prof, course) && GetWeeklyHours(course.hours) + currentTeachingHours <= 30;

    //Which is equivalent to:    
    //if (HasDiscipline(prof, course) && GetWeeklyHours(course.hours) + currentTeachingHours <= 30) return true;
    //return false;
}

bool HasCompletedCourse(aStudent student, string courseID)
{
    return student.completedCourses.Contains(Convert.ToString(courseID));

    //Which is equivalent to:
    //for (int i = 0; i < student.completedCourses.Length; i++)
    //{
    //    if (Convert.ToString(courseID) == student.completedCourses[i]) return true;
    //}
    //return false;
}

bool HasPrerequisites(aStudent student, aCourse course)
{
    int completedPrerequisites = 0;

    foreach (string prerequisite in course.prerequisites)
    {
        if (HasCompletedCourse(student, prerequisite)) completedPrerequisites++;
    }
    return completedPrerequisites == course.counterOfPrerequisites;
}

bool RegisterCourse(aStudent student, aCourse course)
{
    return !HasCompletedCourse(student, course.courseID) && HasPrerequisites(student, course);
}

// Functions for validations:
string YesOrNoValidation()
{
    string ans;
    bool ansIsValid = false;
    do
    {
        ans = Console.ReadLine().ToLower();
        if (ans == "y" || ans == "n") ansIsValid = true;
        else Console.Write("You made an invalid entry. Enter 'y' for yes or 'n' for no.\nPlease try again: ");
    } while (!ansIsValid);
    return ans;
}

int ValidateInt()
{
    int validatedInt;
    bool intIsValid;
    do
    {
        intIsValid = Int32.TryParse(Console.ReadLine(), out validatedInt);
        Console.WriteLine(!intIsValid ? "\nSorry, you entered an invalid value. Please try again." : "");
    } while (!intIsValid);
    return validatedInt;
}

string ValidateString()
{
    string validatedString;
    do
    {
        validatedString = Console.ReadLine();
        Console.WriteLine(validatedString == "" ? "\nSorry, you entered an invalid answer. Please try again." : "");
    } while (validatedString == "");
    return validatedString;
}

float ValidateFloat()
{
    float validatedFloat;
    bool floatIsValid;
    do
    {
        floatIsValid = Single.TryParse(Console.ReadLine(), out validatedFloat);
        Console.WriteLine(!floatIsValid ? "\nSorry, you entered an invalid value. Please try again." : "");
    } while (!floatIsValid);
    return validatedFloat;
}

// Structs:
struct aProfessor
{
    public int professorID;
    public string professorName;
    public float seniority;
    public string[] disciplines;
    public byte counterOfDisciplines;
}

struct aStudent
{
    public int studentID;
    public string studentName;
    public string[] completedCourses;
    public byte counterOfCompletedCourses;
}

struct aCourse
{
    public string courseID;
    public string title;
    public short hours;
    public string discipline;
    public string[] prerequisites;
    public byte counterOfPrerequisites;
    public string[] specs;
    public byte counterOfSpecs;
}
