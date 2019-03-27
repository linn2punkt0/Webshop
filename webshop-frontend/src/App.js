import React, { Component } from "react";
import "./App.css";
import Navbar from "./components/Navbar.js";
import CartPage from "./components/CartPage.js";
import ProductPage from "./components/ProductPage.js";
import { Router } from "@reach/router";

class App extends Component {
  state = {
    products: [],
    cart: []
  };

  componentDidMount = () => {
    this.getAllProducts();
  };

  getAllProducts = () => {
    return fetch("https://localhost:5001/api/Product")
      .then(response => response.json())
      .then(data => {
        this.setState({ products: data });
      })
      .catch(error => console.error(error));
  };

  getProductsById = id => {
    return fetch(`https://localhost:5001/api/Product/${id}`)
      .then(function(response) {
        return response.json();
      })
      .then(function(myJson) {
        let products = myJson;
        return products;
      })
      .catch(error => console.error(error));
  };

  addProductsToCart = id => {
    this.setState = {
      cart: { id }
    };
    console.log("product added!");
  };

  addOrder = () => {};

  render() {
    return (
      <div className="App">
        <header className="App-header" />
        <Navbar />
        <Router>
          <ProductPage
            addToCart={this.addProductsToCart}
            products={this.state.products}
            path="/products"
          />
          <CartPage cart={this.state.cart} path="/cart" />
        </Router>
      </div>
    );
  }
}

export default App;
