package main

import (
	"fmt"
	"time"
)

func main() {
	start := time.Now()
	time.Sleep(2 * time.Second)
	end := time.Now()
	fmt.Println("Slept for", end.Sub(start))
}
