import React from "react";
import styled from "styled-components";

const StyledForm = styled.form`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin: 20px;

  input {
    margin: 5px;
  }
`;

const Form = props => {
  return (
    <StyledForm>
      <label htmlFor="name">Please enter your full name:</label>
      <input name="name" type="text" placeholder="first name and last name" />
      <label htmlFor="adress">Please enter your street adress:</label>
      <input name="adress" type="text" placeholder="street adress" />
      <label htmlFor="post">Please enter your postal code:</label>
      <input name="post" type="text" placeholder="postal code" />
      <label htmlFor="city">Please enter your city:</label>
      <input name="city" type="text" placeholder="city" />
      <label htmlFor="country">Please enter your country:</label>
      <input name="country" type="text" placeholder="country" />
      <label htmlFor="email">Please enter your email:</label>
      <input name="email" type="text" placeholder="email" />
      <label htmlFor="phone">Please enter your phone number:</label>
      <input name="phone" type="text" placeholder="phone number" />
    </StyledForm>
  );
};

export default Form;
