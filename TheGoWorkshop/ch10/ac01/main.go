package main

import (
	"fmt"
	"time"
)

func main() {
	current := time.Now()
	fmt.Println(current.Format("15:04:05 2006/1/2"))
}
