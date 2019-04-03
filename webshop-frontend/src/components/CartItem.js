import React from "react";
import styled from "styled-components";

const StyledCartItem = styled.li`
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;

  h3,
  p {
    margin: 10px;
  }
`;

const CartItem = props => {
  return (
    <StyledCartItem>
      <h3>{props.product.name}</h3>
      <p>{props.product.price}kr</p>
      <p>{props.product.size}cl</p>
    </StyledCartItem>
  );
};

export default CartItem;
