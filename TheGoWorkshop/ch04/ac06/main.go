package main

import (
	"fmt"
)

func getType(v interface{}) string {
	switch v.(type) {
	case bool:
		return "bool"

	case string:
		return "string"
	case int, int8, int16, int32, int64:
		return "int"
	// case byte: // alias for uint8
	// return "byte"
	// case rune: // alias for int32, represents a Unicode code point
	// return "rune"
	case uint, uint8, uint16, uint32, uint64, uintptr:
		return "uint"
	case float32, float64:
		return "float"
	case complex64, complex128:
		return "complex"
	default:
		return "unknown"
	}
}

func getData() []interface{} {
	return []interface{}{
		1,
		3.14,
		"hello",
		true,
		struct{}{},
	}
}

func main() {
	data := getData()
	for i := 0; i < len(data); i++ {
		fmt.Printf("%v is %v\n", data[i], getType(data[i]))
	}

}
