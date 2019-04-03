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
  const [productsInCart, setProductsInCart] = useState([]);

  useEffect(() => {
    getCartItemsById(props.cart);
  }, []);

  const getCartItemsById = id => {
    fetch(`https://localhost:5001/api/cart/${id}`)
      .then(function(response) {
        return response.json();
      })
      .then(function(myJson) {
        setProductsInCart(myJson);
      })
      .catch(error => console.error(error));
  };

  console.log(productsInCart);

  return (
    <StyledCartPage>
      <div className="line" />
      <div className="cartContent">
        <ul>
          {productsInCart.map(element => (
            <CartItem product={element} />
          ))}
        </ul>
      </div>
      <h2>
        Want to place an order? Enter your contact and delivery info below.
      </h2>
      <div className="line" />
      <Form cart={props.cart} />
      {/* <Button>Place order!</Button> */}
    </StyledCartPage>
  );
};

export default CartPage;
