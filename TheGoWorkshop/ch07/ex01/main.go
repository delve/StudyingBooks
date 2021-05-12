package main

import "fmt"

type Speaker interface {
	Speak() string
}

type person struct {
	name      string
	age       int
	isMarried bool
}

func (p person) String() string {
	return fmt.Sprintf("%v (%v years old).\nMarried status: %v", p.name, p.age, p.isMarried)
}
func (p person) Speak() string {
	return "Hello my name is" + p.name
}

func main() {
	p := person{name: "Cailyn", age: 44, isMarried: false}
	fmt.Println(p.Speak())
	fmt.Println(p)

	var str interface{} = "some string"
	v, _ := str.(int)
	fmt.Println(v)
}
