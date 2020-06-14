import * as React from "react";
import { Row, Col } from "antd";
import styles from "./General.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import WristLengthSelect from "../../FormsComponets/WristLengthSelect/WristLengthSelect";
import ChestСircumferenceSelect from "../../FormsComponets/ChestСircumferenceSelect/ChestСircumferenceSelect";
import { IGeneralResult } from "../../../../common/Interfaces";
import {GeneralCalculate} from "./Actions/GeneralCalculate";

const General = () => {
  let heightDefault = 148;
  let ageDefault = 20;
  let wristLengthDefault = 0;
  let chestСircumferenceDefault = 0;

  let def: IGeneralResult[] = []

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);
  const [age, setAge] = useState(ageDefault);
  const [chestСircumference, setChestСircumference] = useState(
    chestСircumferenceDefault
  );
  const [wristLength, setWristLength] = useState(wristLengthDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await GeneralCalculate(height, isMan, age,wristLength, chestСircumference));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Общий калькулятор"}
          description={
            "При заполнении всех полей произведет рассчет по всем калькуляторам идеальной массы тела."
          }
        />
      </Col>

      <Col xl={3} className={styles.genderSelect}>
        <GenderSelect isMan={isMan} setIsMan={setIsMan} />
      </Col>

      <Col xl={3}>
        <AgeSelect setAction={setAge} default={ageDefault} min={20} max={69} />
      </Col>

      <Col xl={5}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={148}
          max={190}
        />
      </Col>
      <Col xl={24} className={styles.genderSelect}>
        <ChestСircumferenceSelect
          setAction={setChestСircumference}
          default={chestСircumference}
          min={0}
          max={400}
        />
      </Col>
      <Col xl={24}>
        <WristLengthSelect
          setWristLength={setWristLength}
          default={chestСircumferenceDefault}
          min={0}
          max={50}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <Result result={result} error={undefined} />
      </Col>
      <Col xl={24}>
        <br/>
        <br/>
        <br/>
      </Col>
    </Row>
  );
};
export default General;
