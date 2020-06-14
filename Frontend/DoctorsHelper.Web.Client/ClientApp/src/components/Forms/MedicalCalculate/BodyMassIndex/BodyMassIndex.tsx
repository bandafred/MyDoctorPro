import * as React from "react";
import { Row, Col } from "antd";
import styles from "./BodyMassIndex.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import { BodyMassIndexResponse } from "../../../../apiClient/apiClient";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import WeightSelect from '../../FormsComponets/Weight/WeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {BodyMassIndexResult} from "./BodyMassIndexAction";

const BodyMassIndex = () => {
  let heightDefault = 170;
  let weightDefault = 70;
  let def: IResult<BodyMassIndexResponse> = {
    error: undefined,
    result: undefined,
  };

  const [weight, setWeight] = useState(weightDefault);
  const [height, setHeight] = useState(heightDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await BodyMassIndexResult(height, weight));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Индекс массы тела"}
          description={[
            "Индекс массы тела (англ. body mass index (BMI), ИМТ) — величина, позволяющая оценить степень соответствия массы человека и его роста и тем самым косвенно оценить, является ли масса недостаточной, нормальной или избыточной. Важен при определении показаний для необходимости лечения.",
            "Индекс массы тела рассчитывается по формуле:  ИМТ = m/h^2, где: m — масса тела в килограммах, h — рост в метрах и измеряется в кг/м²."
          ]}
        />
      </Col>

      <Col xl={5}>
      <WeightSelect
          setAction={setWeight}
          default={weightDefault}
          min={30}
          max={500}
        />
      </Col>

      <Col xl={11}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={140}
          max={350}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate result={result.result?.result} error={result.error} index={result.result?.index}/>
      </Col>
    </Row>
  );
};
export default BodyMassIndex;
