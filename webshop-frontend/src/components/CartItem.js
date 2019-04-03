import React from "react";
import styled from "styled-components";

const StyledCartItem = styled.div``;

const CartItem = props => {
  return (
    <StyledCartItem>
      <p>{props.productId}</p>
    </StyledCartItem>
  );
};

export default CartItem;
