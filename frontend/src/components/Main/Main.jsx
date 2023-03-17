import styles from "./styles.module.css";
import { Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";

const Main = () => {


  return (
    <div className={styles.main_container}>
      <nav className={styles.navbar}>
        <h1>Tesla cars rental </h1>
        <Link to="/AddRental">
          <button type="button" className={styles.white_btn}>
            Nowa rezerwacja
          </button>
        </Link>
        <Link to="/GetAllRentalPoints">
          <button type="button" className={styles.white_btn}>
            Nasze placówki
          </button>
        </Link>
      </nav>
    </div>
  );
};
export default Main;
