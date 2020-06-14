import * as React from "react";
import { Row, Col } from "antd";
import styles from "./HASBLED.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { HASBLEDResponse } from "../../../../apiClient/apiClient";
import {HASBLEDResult} from "./HASBLEDAction";

const HASBLED = () => {
  let def: IResult<HASBLEDResponse> = {
    error: undefined,
    result: undefined,
  };

  const [hypertension, setHypertension] = useState(false);
  const [creatinineIncreased, setCreatinineIncreased] = useState(false);
  const [transaminase, setTransaminase] = useState(false);
  const [insult, setInsult] = useState(false);
  const [bleeding, setBleeding] = useState(false);
  const [mno, setMno] = useState(false);
  const [oldAge, setOldAge] = useState(false);
  const [antiplateletAgents, setAntiplateletAgents] = useState(false);
  const [alcohol, setAlcohol] = useState(false);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(
      await HASBLEDResult(
        hypertension,
        creatinineIncreased,
        transaminase,
        insult,
        bleeding,
        mno,
        oldAge,
        antiplateletAgents,
        alcohol
      )
    );
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={
            "Шкала HAS-BLED – это простой и надежный клинический инструмент для оценки риска большого кровотечения в течение 1 года"
          }
          description={[
            "HAS-BLED — шкала для оценки риска кровотечений. Акроним от Hypertension, Abnormal renal-liver function, Stroke, Bleeding history or predisposition, Labile international normalized ratio, Elderly (65 years), Drugs or alcohol concomitantly.",
          ]}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Артериальная гипертония (АД >160 мм рт.ст.)"}
          setAction={setHypertension}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={
            "Нарушение функции почек (креатинин сыворотки более 200 мкмоль/л)"
          }
          setAction={setCreatinineIncreased}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={
            "Нарушение функции печени (повышение АЛТ/АСТ/щелочной фосфатазы > 3 раза от верхней границы нормы)"
          }
          setAction={setTransaminase}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect text={"Инсульт в анамнезе"} setAction={setInsult} />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={"Кровотечения (со снижением Hb>2 г/л)"}
          setAction={setBleeding}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Неустойчивое МНО (<60% времени в терапевтическом диапазоне)"}
          setAction={setMno}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Пожилой возраст (> 65 лет)"}
          setAction={setOldAge}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={
            "Лекарственные препараты (Совместный прием лекарств, усиливающих кровоточивость: антиагреганты, НПВП)"
          }
          setAction={setAntiplateletAgents}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Алкоголь (> 8 стаканов в неделю)"}
          setAction={setAlcohol}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate
          result={result.result?.result}
          error={result.error}
        />
      </Col>
    </Row>
  );
};
export default HASBLED;
