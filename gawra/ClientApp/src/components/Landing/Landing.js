import React, { Component } from "react";
import LoginRegisterBox from "./LoginRegisterBox";
import "../../styles/Landing.css";

export class Landing extends Component {
  render() {
    return (
      <>
        <div className="landing-content">
          <img id="gawra-img" src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/0a26f8e0-55ff-4944-8fb8-b745353978e9/de5f51x-9a449f9e-6691-44c1-b383-76b5fdd02a57.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzBhMjZmOGUwLTU1ZmYtNDk0NC04ZmI4LWI3NDUzNTM5NzhlOVwvZGU1ZjUxeC05YTQ0OWY5ZS02NjkxLTQ0YzEtYjM4My03NmI1ZmRkMDJhNTcucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.QUtIW88N1sq9qjicQhlcVR5hzU4e92skliZSF6c72nQ"></img>
          <LoginRegisterBox />
        </div>
      </>
    );
  }
}
