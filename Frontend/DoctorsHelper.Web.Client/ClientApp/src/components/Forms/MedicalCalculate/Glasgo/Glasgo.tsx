import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import { IResult, ISelectNameValue } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { GlasgoResponse } from "../../../../apiClient/apiClient";
import SelectedNameValue from "../../FormsComponets/SelectedNameValue/SelectedNameValue";
import {GlasgoResult} from "./GlasgoAction";

const Glasgo = () => {
  let def: IResult<GlasgoResponse> = {
    error: undefined,
    result: undefined,
  };

  let eyeResponseVal: ISelectNameValue[] = [
    { name: "Произвольное", value: 4},
    { name: "Как реакция на вербальный стимул",value: 3 },
    { name: "Как реакция на болевое раздражение", value: 2 },
    { name: "Отсутствует", value: 1 },
  ];

  let verbalResponseVal: ISelectNameValue[] = [
    { name: "Больной ориентирован, быстрый и правильный ответ на заданный вопрос", value: 5},
    { name: "Больной дезориентирован, спутанная речь", value: 4},
    { name: "Словесная окрошка, ответ по смыслу не соответствует вопросу",value: 3 },
    { name: "Нечленораздельные звуки в ответ на заданный вопрос", value: 2 },
    { name: "Отсутствие речи", value: 1 },
  ];

  let motorResponseVal: ISelectNameValue[] = [
    { name: "Выполнение движений по команде", value: 6},
    { name: "Целенаправленное движение в ответ на болевое раздражение (отталкивание)", value: 5},
    { name: "Отдёргивание конечности в ответ на болевое раздражение", value: 4},
    { name: "Патологическое сгибание в ответ на болевое раздражение",value: 3 },
    { name: "Патологическое разгибание в ответ на болевое раздражение", value: 2 },
    { name: "Отсутствие движений", value: 1 },
  ];

let eyeResponseDefault = 4;
let verbalResponseDefault = 5;
let motorResponseDefault = 6;
  
  const [eyeResponse, setEyeResponse] = useState(eyeResponseDefault);
  const [verbalResponse, setVerbalResponse] = useState(5);
  const [motorResponse, setmotorResponse] = useState(6);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(
      await GlasgoResult(
        eyeResponse,
        verbalResponse,
        motorResponse,
      )
    );
    setIsLoad(false);
  };

  return (
    <Row style={{ marginBottom: 100 }}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Шкала комы Глазго"}
          description={[
            "Шкала для оценки степени нарушения сознания и комы детей старше 4 лет и взрослых. Шкала была опубликована в 1974 году Грэхэмом Тиздейлом и Б. Дж. Дженнетт, профессорами нейрохирургии Института Неврологических наук Университета Глазго.",
            "Шкала состоит из трёх тестов, оценивающих реакцию открывания глаз (E), а также речевые (V) и двигательные (M) реакции. За каждый тест начисляется определённое количество баллов. В тесте открывания глаз от 1 до 4, в тесте речевых реакций от 1 до 5, а в тесте на двигательные реакции от 1 до 6 баллов. Таким образом, минимальное количество баллов — 3 (глубокая кома), максимальное — 15 (ясное сознание).",
          ]}
        />
      </Col>

      <Col xl={24} style={{ marginTop: 10, marginLeft: 35 }}>
        <SelectedNameValue
          setAction={setEyeResponse}
          name={"Открывание глаз"}
          width={570}
          values={eyeResponseVal}
        />
      </Col>

      <Col xl={24} style={{ marginTop: 10, marginLeft: 35 }}>
        <SelectedNameValue
          setAction={setVerbalResponse}
          name={"Речевая реакция"}
          width={570}
          values={verbalResponseVal}
        />
      </Col>

      <Col xl={24} style={{ marginTop: 10 }}>
        <SelectedNameValue
          setAction={setmotorResponse}
          name={"Двигательная реакция"}
          width={570}
          values={motorResponseVal}
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
export default Glasgo;
