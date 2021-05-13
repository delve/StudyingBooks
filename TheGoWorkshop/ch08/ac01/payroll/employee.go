package payroll

import "fmt"

type Employee struct {
	Id        int
	FirstName string
	LastName  string
}

func (e Employee) FullName() string {
	return fmt.Sprintf("%s %s", e.FirstName, e.LastName)
}
