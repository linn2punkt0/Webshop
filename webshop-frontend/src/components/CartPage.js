import React, { useState, useEffect } from "react";
import styled from "styled-components";
import Form from "./Form.js";
import Button from "./Button.js";
import CartItem from "./CartItem.js";

const StyledCartPage = styled.div`
  .line {
    height: 2px;
    width: 96vw;
    margin: auto;
    background-color: #4a97bd;
  }
  .cartContent {
    min-height: 200px;
  }
`;

const CartPage = props => {
  const [productIds, setProductIds] = useState(null);
  const [productsInCart, setProductsInCart] = useState(true);

  useEffect(() => {
    getCartItemsById(props.cart);
    getProductsById(productIds);
  }, []);

  const getCartItemsById = id => {
    fetch(`https://localhost:5001/api/cart/${id}`)
      .then(function(response) {
        return response.json();
      })
      .then(function(myJson) {
        // Här får jag ut ett product id, hur plocka ut alla och loopa för att fetcha info?
        console.log(myJson[0].product_id);

        setProductIds(...myJson);
      })
      .catch(error => console.error(error));
  };

  const getProductsById = id => {
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

  // Nått sånt här fast som funkar.
  productIds.map(element) => {
    setProductsInCart(getProductsById(element))
  };

  return (
    <StyledCartPage>
      <div className="line" />
      <div className="cartContent">
        {/* <ul> */}
        {/* {productsInCart.map(element => (
          <CartItem productId={element} />
        ))} */}
        {/* </ul> */}
      </div>
      <h2>
        Want to place an order? Enter your contact and delivery info below.
      </h2>
      <div className="line" />
      <Form />
      <Button>Place order!</Button>
    </StyledCartPage>
  );
};

export default CartPage;
