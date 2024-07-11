let cardNumber = "1234 5678 1234 5678";
let cardPin = "1234";
const depositAmount = 20000;
const withdrawAmount = 10000;

const validateCard = async (cardNumber) => {
  try {
    if (!cardNumber && cardNumber.length === 16) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const validatePin = async (cardNumber, cardPin) => {
  try {
    if (!cardNumber && !cardPin && cardPin.length === 4) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const deposit = async (cardNumber, Amount) => {
  try {
    if (!cardNumber && Amount > 0 && depositAmount <= Amount) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const withdraw = async (cardNumber, cardPin, Amount) => {
  try {
    if (!cardNumber && !cardPin && Amount > 0 && withdrawAmount <= Amount) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const checkBalance = async (cardNumber, cardPin) => {
  try {
    if (!cardNumber && !cardPin) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};
