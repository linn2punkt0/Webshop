import React from "react";
import styled from "styled-components";

const StyledCartPage = styled.div``;

const CartPage = props => {
  return (
    <StyledCartPage>
      <ul>
        {props.cart.map(element => (
          <li>{element}</li>
        ))}
      </ul>
    </StyledCartPage>
  );
};

export default CartPage;
