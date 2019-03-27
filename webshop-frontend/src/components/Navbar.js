import React from "react";
import styled from "styled-components";
import { Link } from "@reach/router";

const StyledNavbar = styled.div`
  width: 98vw;
  height: 100px;
  a {
    color: black;
    text-decoration: none;
    font-weight: 700;
    font-size: 30px;
    margin: 10px;
  }

  @media screen and (min-width: 800px) {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    font-size: 40px;
  }
`;

const Navbar = () => {
  return (
    <StyledNavbar>
      {" "}
      <h2>Gin-shop</h2>
      <Link to="/products">Products</Link>
      <Link to="/cart">Cart</Link>
    </StyledNavbar>
  );
};

export default Navbar;
