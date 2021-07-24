import React, { Component } from "react";
import LoginRegisterBox from "./LoginRegisterBox";
import "../../styles/Landing.css";

export class Landing extends Component {
  render() {
    return (
      <>
        <div className="landing-container container-left">
          <h1>This is the gawra landing page!</h1>
        </div>
        <div className="landing-container container-right">
          <LoginRegisterBox />
        </div>
      </>
    );
  }
}
