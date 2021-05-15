package main

import (
	"bytes"
	"encoding/gob"
	"fmt"
	"io"
	"log"
)

type UserClient struct {
	Id   string
	Name string
}

type TxClient struct {
	Id          string
	User        *UserClient
	AccountFrom string
	AccountTo   string
	Amount      float64
}

type UserServer struct {
	Id string
}

type TxServer struct {
	Id          string
	User        UserServer
	AccountFrom string
	AccountTo   string
	Amount      *float32
}

func main() {
	var net bytes.Buffer
	clientTx := &TxClient{
		Id: "123456789",
		User: &UserClient{
			Id:   "ABCDEF",
			Name: "James",
		},
		AccountFrom: "Bob",
		AccountTo:   "Jane",
		Amount:      9.99,
	}
	enc := gob.NewEncoder(&net)

	if err := enc.Encode(clientTx); err != nil {
		log.Fatal("error encoding: ", err)
	}
	serverTx, err := sendToServer(&net)
	if err != nil {
		log.Fatal("server error: ", err)
	}

	fmt.Printf("%#v\n", serverTx)
	fmt.Printf("%v", *serverTx.Amount)
}

func sendToServer(net io.Reader) (*TxServer, error) {
	tx := &TxServer{}
	dec := gob.NewDecoder(net)
	err := dec.Decode(tx)
	return tx, err
}
