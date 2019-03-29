import React, { Component } from "react";
import "./App.css";
import Navbar from "./components/Navbar.js";
import CartPage from "./components/CartPage.js";
import ProductPage from "./components/ProductPage.js";
import { Router } from "@reach/router";

class App extends Component {
  state = {
    products: []
  };
  componentDidMount = () => {
    this.getAllProducts();
  };

  getAllProducts = () => {
    return fetch("https://localhost:5001/api/product")
      .then(response => response.json())
      .then(data => {
        this.setState({ products: data });
      })
      .catch(error => console.error(error));
  };

  getProductsById = id => {
    return fetch(`https://localhost:5001/api/product/${id}`)
      .then(function(response) {
        return response.json();
      })
      .then(function(myJson) {
        let products = myJson;
        return products;
      })
      .catch(error => console.error(error));
  };

  addProductsToCart = (id, product_id) => {
    const body = {
      product_id,
      cart_id: id
    };
    fetch(`https://localhost:5001/api/cart`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(body)
    })
      .then(function(response) {
        return response.json();
      })
      .then(function(myJson) {
        let cart_id = myJson;
        console.log(cart_id);
      })
      .catch(error => console.error(error));

    console.log(id);
  };

  // getCartItemsById = id => {
  //   fetch(`https://localhost:5001/api/cart/${id}`)
  //     .then(function(response) {
  //       return response.json();
  //     })
  //     .then(function(myJson) {
  //       let cartItems = myJson;
  //     })
  //     .catch(error => console.error(error));
  // };

  // addOrder = () => {
  //   fetch(`https://localhost:5001/api/order`, { method: POST })
  //     .then(function(response) {
  //       return response.json();
  //     })
  //     .then(function(myJson) {})
  //     .catch(error => console.error(error));

  //   console.log(id);
  // };

  // getOrderById = () => {
  //   fetch(`https://localhost:5001/api/order/${id}`)
  //     .then(function(response) {
  //       return response.json();
  //     })
  //     .then(function(myJson) {
  //       let order = myJson;
  //     })
  //     .catch(error => console.error(error));
  // };

  render() {
    return (
      <div className="App">
        <header className="App-header" />
        <Navbar />
        <Router>
          <ProductPage
            addToCart={this.addProductsToCart}
            products={this.state.products}
            path="/"
          />
          <CartPage cart={this.state.cart} path="/cart" />
        </Router>
      </div>
    );
  }
}

export default App;
