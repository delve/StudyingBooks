package main

import (
	"errors"
	"fmt"
	"log"
	"regexp"
	"strings"
)

var (
	ErrInvalidSSNLength  = errors.New("invalid SSN length")
	ErrInvalidSSNNumbers = errors.New("non-numeric value")
	ErrInvalidSSNPrefix  = errors.New("three 0s for prefix")
	ErrInvalidDigitPlace = errors.New("prefix 9 requires 7 or 9 in fourth digit")
)

func stripDash(s string) string {
	return strings.ReplaceAll(s, "-", "")
}

func validateLength(ssn string) error {
	if len(stripDash(ssn)) != 9 {
		return fmt.Errorf("invalid SSN %s: %v", ssn, ErrInvalidSSNLength)
	}
	return nil
}

func validateBytes(ssn string) error {
	if m, _ := regexp.MatchString("[^\\d]", stripDash(ssn)); m {
		return fmt.Errorf("invalid SSN %s: %v", ssn, ErrInvalidSSNNumbers)
	}
	return nil
}

func validatePrefix(ssn string) error {
	if strings.HasPrefix(ssn, "000") {
		return fmt.Errorf("invalid SSN %s: %v", ssn, ErrInvalidSSNPrefix)
	}
	return nil
}

func validateNinePrefix(ssn string) error {
	s := stripDash(ssn)
	if strings.HasPrefix(s, "9") && string(s[3]) != "7" && string(s[3]) != "9" {
		return fmt.Errorf("invalid SSN %s: %v", ssn, ErrInvalidDigitPlace)
	}
	return nil
}

func main() {
	testSSN := []string{"123-45-6789", "012-8-678", "000-12-0962", "999-33-3333", "087-65-4321", "123-45-zzzz"}

	log.SetFlags(log.Ldate | log.Lmicroseconds | log.Llongfile)
	log.Printf("Checking data %#v\n", testSSN)
	for i, v := range testSSN {
		log.Printf("Validate data \"%v\" %d of %d", v, i, len(testSSN))
		if err := validateLength(v); err != nil {
			log.Print(err)
		}
		if err := validateBytes(v); err != nil {
			log.Print(err)
		}
		if err := validatePrefix(v); err != nil {
			log.Print(err)
		}
		if err := validateNinePrefix(v); err != nil {
			log.Print(err)
		}
	}
}
