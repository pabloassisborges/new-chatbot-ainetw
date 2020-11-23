import React, { Component } from "react";
import "./Pizza.css";
import "bootstrap/dist/css/bootstrap.min.css";
import CustomChatbot from "../chatbot/CustomChatbot";

class Pizza extends Component {
  render() {
    return (
      <div>
        <div className="container mt-5">
          <CustomChatbot />
        </div>
      </div>
    );
  }
}

export default Pizza;
