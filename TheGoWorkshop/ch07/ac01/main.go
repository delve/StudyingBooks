package main

import (
	"errors"
	"fmt"
)

type Employee struct {
	Id        int
	FirstName string
	LastName  string
}

type rating float64

var ratings = map[string]int{
	"Unsatisfactory": 1,
	"Poor":           2,
	"Fair":           3,
	"Good":           4,
	"Excellent":      5,
}

type Developer struct {
	Individual        Employee
	HourlyRate        int
	HoursWorkedInYear int
	Review            map[string]interface{}
}

type Manager struct {
	Individual     Employee
	Salary         int
	CommissionRate float64
}

type Payer interface {
	Pay() (string, float64)
}

func (e Employee) FullName() string {
	return fmt.Sprintf("%s %s", e.FirstName, e.LastName)
}

func (d Developer) Pay() (string, float64) {
	name := d.Individual.FullName()
	netPay := float64(d.HourlyRate * d.HoursWorkedInYear)
	return name, netPay
}

func (m Manager) Pay() (string, float64) {
	name := m.Individual.FullName()
	salary := float64(m.Salary)
	netPay := salary + (salary * m.CommissionRate)
	return name, netPay
}

func payDetails(p Payer) {
	name, pay := p.Pay()
	fmt.Println(name, " got paid ", pay)
}

func calculateReviewScore(review map[string]interface{}) float64 {
	score := 0
	for _, x := range review {
		switch v := x.(type) {
		case int:
			score += int(v)
		case string:
			score += ratings[string(v)]
		default:
			panic(errors.New(fmt.Sprintf("Unknown rating %v", v)))
		}
	}
	return float64(score) / float64(len(review))
}

func reviewDetails(d Developer) {
	fmt.Println(d.Individual.FullName(), " got a review rating of ", calculateReviewScore(d.Review))
}

func main() {
	employeeReview := make(map[string]interface{})
	employeeReview["workquality"] = 5
	employeeReview["teamwork"] = 2
	employeeReview["communication"] = "Poor"
	employeeReview["problemsolving"] = 4
	employeeReview["dependability"] = "Unsatisfactory"
	employees := []interface{}{
		Manager{Individual: Employee{FirstName: "Mr.", Id: 1, LastName: "Boss"}, Salary: 150000, CommissionRate: .07},
		Developer{Individual: Employee{FirstName: "Eric", Id: 1, LastName: "Davis"}, HourlyRate: 35, HoursWorkedInYear: 2400, Review: employeeReview},
	}
	for _, t := range employees {
		switch v := t.(type) {
		case Developer:
			reviewDetails(v)
			payDetails(v)
		case Manager:
			payDetails(v)
		default:
			panic(errors.New(fmt.Sprintf("Unknown employee type %v", v)))
		}
	}
}
