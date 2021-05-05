package main

import (
	"fmt"
	"strconv"
)

func main() {
	var (
		countMin = 1
		countMax = 100
		out      = ""
	)

	for i := countMin; i <= countMax; i++ {
		// fmt.Printf("%v %v %v yeilds: ", i, i%3, i%5)
		out = ""
		if i%3 == 0 {
			out += "Fizz"
		}
		if i%5 == 0 {
			out += "Buzz"
		}
		if len(out) < 1 {
			out = strconv.Itoa(i)
		}
		fmt.Println(out)
	}

}
