package payroll

type Developer struct {
	Individual        Employee
	HourlyRate        int
	HoursWorkedInYear int
	Review            map[string]interface{}
}

func (d Developer) Pay() (string, float64) {
	name := d.Individual.FullName()
	netPay := float64(d.HourlyRate * d.HoursWorkedInYear)
	return name, netPay
}
