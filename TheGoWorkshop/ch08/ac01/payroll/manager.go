package payroll

type Manager struct {
	Individual     Employee
	Salary         int
	CommissionRate float64
}

func (m Manager) Pay() (string, float64) {
	name := m.Individual.FullName()
	salary := float64(m.Salary)
	netPay := salary + (salary * m.CommissionRate)
	return name, netPay
}
