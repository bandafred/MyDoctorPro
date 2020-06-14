import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {
    CorrectedQTCalculationResponse,
} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {CorrectedQTCalculationResult} from "./CorrectedQTCalculationAction";

const CorrectedQTCalculation = () => {
  let def: IResult<CorrectedQTCalculationResponse> = {
    error: undefined,
    result: undefined,
  };

  const [heartRate, serHeartRate] = useState(90);
  const [intervalQT, setIntervalQT] = useState(340);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await CorrectedQTCalculationResult(heartRate, intervalQT));
    setIsLoad(false);
  };

  return (
    <Row style={{ marginBottom: 100 }}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Расчет корригированного QT"}
          description={[
            "Продолжительность интервала QT отражает время реполяризации желудочков сердца. Нормальная продолжительность интервала QT зависит от текущей частоты сердечного ритма. С диагностической целью чаще всего используют абсолютный показатель QTс (корригированный интервал QT), который рассчитывается по нескольким формулам. В расчет этого показателя введена поправка на текущую частоту сердечного ритма.",
            "Формула Базетта (Bazett’s formula) может быть использована у пациентов с ЧСС от 60 до 100 ударов в минуту. При тахикардии или брадикардии значения могут быть искажены. Для ЧСС ниже 60 или выше 100 ударов в минуту определение корригированного значения интервала QT должно быть подсчитано по формуле Framingham. Нормальные значения корригированного QT: 320-430 для мужчин и 320-450 для женщин.",
          ]}
        />
      </Col>

      <Col xl={7} style={{ marginTop: 10 }}>
        <InputInt
          default={90}
          max={999}
          min={1}
          setAction={serHeartRate}
          preName={"Частота сердечных сокращений"}
          postName={"уд/мин."}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={340}
          max={999}
          min={1}
          setAction={setIntervalQT}
          preName={"QT"}
          postName={"мсек."}
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
export default CorrectedQTCalculation;
