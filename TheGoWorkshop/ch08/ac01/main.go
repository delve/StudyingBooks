package main

import (
	"fmt"

	"example.com/m/payroll"
)

type rating float64

var ratings = map[string]int{}

type Payer interface {
	Pay() (string, float64)
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
			panic(fmt.Errorf("unknown rating %v", v))
		}
	}
	return float64(score) / float64(len(review))
}

func reviewDetails(d payroll.Developer) {
	fmt.Println(d.Individual.FullName(), " got a review rating of ", calculateReviewScore(d.Review))
}

func init() {
	fmt.Println("Greetz")
}

func init() {
	fmt.Println("Initializing")
	ratings["Unsatisfactory"] = 1
	ratings["Poor"] = 2
	ratings["Fair"] = 3
	ratings["Good"] = 4
	ratings["Excellent"] = 5

}

func main() {
	employeeReview := make(map[string]interface{})
	employeeReview["workquality"] = 5
	employeeReview["teamwork"] = 2
	employeeReview["communication"] = "Poor"
	employeeReview["problemsolving"] = 4
	employeeReview["dependability"] = "Unsatisfactory"
	employees := []interface{}{
		payroll.Manager{Individual: payroll.Employee{FirstName: "Mr.", Id: 1, LastName: "Boss"}, Salary: 150000, CommissionRate: .07},
		payroll.Developer{Individual: payroll.Employee{FirstName: "Eric", Id: 1, LastName: "Davis"}, HourlyRate: 35, HoursWorkedInYear: 2400, Review: employeeReview},
	}
	for _, t := range employees {
		switch v := t.(type) {
		case payroll.Developer:
			reviewDetails(v)
			payDetails(v)
		case payroll.Manager:
			payDetails(v)
		default:
			panic(fmt.Errorf("unknown employee type %v", v))
		}
	}
}
