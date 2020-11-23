import React from "react";
import ChatBot from "react-simple-chatbot";
import { ThemeProvider } from "styled-components";
import botAvatar from '../.././assets/images/Bella-icon.png'

function CustomChatbot(props) {
  const config = {
    width: "300px",
    height: "400px",
    floating: true
  };

  const theme = {
    background: "white",
    //fontFamily: "Arial, Helvetica, sans-serif",
    headerBgColor: "#b20000",
    headerFontColor: "#fff",
    headerFontSize: "25px",
    botBubbleColor: "#b20000",
    botFontColor: "#fff",
    userBubbleColor: "#fff",
    userFontColor: "#4c4c4c"
  };

  const steps = [
    {
      id: "Greet",
      message: "Oi, bem vindo ao bot em React.",
      trigger: "Ask Name"
    },
    {
      id: "Ask Name",
      message: "Me fala seu nome?",
      trigger: "Waiting user input for name"
    },
    {
      id: "Waiting user input for name",
      user: true,
      trigger: "Asking options to eat"
    },
    {
      id: "Asking options to eat",
      message: "Oi {previousValue}! Me conta, você quer uma Pizza ou um Burger?",
      trigger: "Displaying options to eat"
    },
    {
      id: "Displaying options to eat",
      options: [
        {
          value: "pizza",
          label: "Pizza",
          trigger: "Done"
        },
        { value: "burger", label: "Burger", trigger: "Burger Not available" }
      ]
    },
    {
      id: "Burger Not available",
      message:
        "Desculpa, a gente não tem Burger no momento. Que tal provar nossa pizza?",
      trigger: "Asking for pizza after burger"
    },
    {
      id: "Asking for pizza after burger",
      options: [
        { value: true, label: "Quero", trigger: "Done" },
        { value: false, label: "Não obrigado", trigger: "Done" }
      ]
    },
    {
      id: "Done",
      message: "Combinado! Tenha um ótimo dia :)",
      end: true
    }
  ];

  return (
    <ThemeProvider theme={theme}>
      <ChatBot 
        headerTitle = "A.I. Net Pizza's"
        recognitionEnable={true}
        botAvatar = {botAvatar}
        speechSynthesis={{ enable: true, lang: 'pt-br' }}
        steps={steps} {...config} 
      />
    </ThemeProvider>
  );
}

export default CustomChatbot;
