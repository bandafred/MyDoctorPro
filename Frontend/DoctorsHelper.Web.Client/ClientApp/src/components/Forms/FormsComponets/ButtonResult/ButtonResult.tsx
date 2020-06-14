import * as React from "react";
import { Button } from "antd";
import styles from "./ButtonResult.module.css";

const ButtonResult = (props: { isLoad: boolean; calcing: Function }) => {
  return (
    <>
      <Button
        className={styles.bnt}
        type="primary"
        loading={props.isLoad}
        onClick={() => props.calcing()}
      >
        Расчитать
      </Button>
    </>
  );
};
export default ButtonResult;
