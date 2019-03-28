import React from "react";
import styled from "styled-components";
import Form from "./Form.js";
import Button from "./Button.js";

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
  return (
    <StyledCartPage>
      <div className="line" />
      <div className="cartContent">
        <ul>
          {props.cart.map(element => (
            <li>{element}</li>
          ))}
        </ul>
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
