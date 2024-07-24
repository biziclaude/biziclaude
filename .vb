Imports System.Collections.Generic
Module EmployeeSalaryTracker
    Sub Main()
        Dim employeeData As New Dictionary(Of String, Dictionary(Of String, Decimal))()
        Console.WriteLine("Employee Salary Tracker")
        Console.WriteLine("-----------------------")
        While True
            Console.Write("Enter employee name (or 'done' to finish): ")
            Dim employeeName As String = Console.ReadLine().Trim()
            If employeeName.ToLower() = "done" Then
                Exit While
            End If
            Dim salaryData As New Dictionary(Of String, Decimal)()
            Console.Write($"Enter {employeeName}'s salary for June: ")
            Dim juneSalary As Decimal = Convert.ToDecimal(Console.ReadLine())
            salaryData.Add("June", juneSalary)
            Console.Write($"Enter {employeeName}'s salary for July: ")
            Dim julySalary As Decimal = Convert.ToDecimal(Console.ReadLine())
            salaryData.Add("July", julySalary)
            Console.Write($"Enter {employeeName}'s salary for August: ")
            Dim augustSalary As Decimal = Convert.ToDecimal(Console.ReadLine())
            salaryData.Add("August", augustSalary)
            employeeData.Add(employeeName, salaryData)
        End While
        Console.WriteLine()
        Console.WriteLine("Recorded Employee Data:")
        Console.WriteLine("-----------------------")
        Console.WriteLine("Name\tJune\tJuly\tAugust")
        For Each kvp In employeeData
            Dim name = kvp.Key
            Dim june = kvp.Value("June")
            Dim july = kvp.Value("July")
            Dim august = kvp.Value("August")
            Console.WriteLine($"{name,-15}{june,-10:C}{july,-10:C}{august,-10:C}")
        Next
        Console.WriteLine()
        SearchAndUpdate(employeeData)
    End Sub
    Sub SearchAndUpdate(employeeData As Dictionary(Of String, Dictionary(Of String, Decimal)))
        Console.Write("Enter employee name to search (or 'done' to exit): ")
        Dim searchName As String = Console.ReadLine().Trim()

        If searchName.ToLower() = "done" Then
            Exit Sub
        End If
        If employeeData.ContainsKey(searchName) Then
            Dim employee = employeeData(searchName)
            Dim totalSalaries = employee.Values.Sum()
            Dim averageSalary = totalSalaries / 3
            Console.WriteLine($"Employee: {searchName}")
            Console.WriteLine($"June Salary: {employee("June"):C}")
            Console.WriteLine($"July Salary: {employee("July"):C}")
            Console.WriteLine($"August Salary: {employee("August"):C}")
            Console.WriteLine($"Total Salaries: {totalSalaries:C}")
            Console.WriteLine($"Average Monthly Salary: {averageSalary:C}")
        Else
            Console.WriteLine($"Employee '{searchName}' not found.")
        End If
        SearchAndUpdate(employeeData)
    End Sub
End Module
