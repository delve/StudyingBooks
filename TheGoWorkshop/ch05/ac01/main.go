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

func main() {
	d := Developer{
		Individual: Employee{Id: 1, FirstName: "Tony", LastName: "Stark"},
		HourlyRate: 10,
		WorkWeek:   [7]int{},
	}
	d.LogHours(Monday, 8)
	d.LogHours(Tuesday, 10)
	fmt.Println("Monday hours:", d.WorkWeek[Monday])
	fmt.Println("Tues Hours:", d.WorkWeek[Tuesday])
	fmt.Println("Week total:", d.HoursWorked())
}
