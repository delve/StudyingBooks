package main

import "fmt"

type Developer struct {
	Individual Employee
	HourlyRate int
	WorkWeek   [7]int
}
type Employee struct {
	Id        int
	FirstName string
	LastName  string
}
type Weekday int

const (
	Sunday Weekday = iota
	Monday
	Tuesday
	Wednesday
	Thursday
	Friday
	Saturday
)

// Implement Stringer
func (w Weekday) String() string {
	return [...]string{"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}[w]
}

func (d *Developer) LogHours(day Weekday, hours int) {
	d.WorkWeek[day] += hours
}
func (d *Developer) HoursWorked() int {
	total := 0
	for _, v := range d.WorkWeek {
		total += v
	}
	return total
}

func nonLoggedHours() func(int) int {
	hours := 0
	return func(i int) int {
		hours += i
		return hours
	}
}

func (d Developer) TotalHours() int {
	totalHours := 0
	for _, hours := range d.WorkWeek {
		totalHours += hours
	}
	return totalHours
}

func (d Developer) PayDay() (pay int, overtime bool) {
	totalHours := d.TotalHours()
	overtime = false
	pay = totalHours * d.HourlyRate
	if totalHours > 40 {
		overtime = true
		pay += (totalHours - 40) * d.HourlyRate
	}
	return pay, overtime
}

func (d Developer) PayDetails() {
	for idx, hours := range d.WorkWeek {
		fmt.Println(Weekday(idx), " hours: ", hours)
	}
	fmt.Println("Hours worked this week: ", d.TotalHours())
	pay, ot := d.PayDay()
	fmt.Println("Pay for this week: ", pay)
	fmt.Println("Overtime?", ot)
}

func main() {
	d := Developer{
		Individual: Employee{Id: 1, FirstName: "Tony", LastName: "Stark"},
		HourlyRate: 10,
		WorkWeek:   [7]int{},
	}
	myTime := nonLoggedHours()
	fmt.Println("Tracking hours today: ", myTime(2))
	fmt.Println("Tracking hours today: ", myTime(3))
	fmt.Println("Tracking hours today: ", myTime(5))

	d.LogHours(Monday, 8)
	d.LogHours(Tuesday, myTime(0))
	d.LogHours(Wednesday, myTime(0))
	d.LogHours(Thursday, myTime(0))
	d.LogHours(Friday, 6)
	d.LogHours(Saturday, 8)

	d.PayDetails()
}
