import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";
import { IResult, ISelectNameValue } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { ContrastInducedNephropathyResponse } from "../../../../apiClient/apiClient";
import SelectedNameValue from "../../FormsComponets/SelectedNameValue/SelectedNameValue";
import {KINResult} from "./KINAction";

const KIN = () => {
  let def: IResult<ContrastInducedNephropathyResponse> = {
    error: undefined,
    result: undefined,
  };

  let volumeContrastVolume: ISelectNameValue[] = [
    { name: "100 мл", value: 1 },
    { name: "200 мл", value: 2 },
    { name: "300 мл", value: 3 },
    { name: "400 мл", value: 4 },
    { name: "> 500 мл", value: 5 },
  ];

  let speedKFVolume: ISelectNameValue[] = [
    { name: "40-60 мл/мин/1,73м2", value: 2 },
    { name: "20-40 мл/мин/1,73м2", value: 4 },
    { name: "< 20 мл/мин/1,73м2", value: 6 },
  ];

  const [isHypotonia, setIsHypotonia] = useState(false);
  const [isVABK, setIsVABK] = useState(false);
  const [isNYHA, setIsNYHA] = useState(false);
  const [isOldAge, setIsOldAge] = useState(false);
  const [isAnemya, setIsAnemya] = useState(false);
  const [isDiabetes, setIsDiabetes] = useState(false);
  const [isBigCreatinin, setIsBigCreatinin] = useState(false);

  const [volumeContrast, setVolumeContrast] = useState(0);
  const [speedKF, setSpeedKF] = useState(0);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(
      await KINResult(
        isHypotonia,
        isVABK,
        isNYHA,
        isOldAge,
        isAnemya,
        isDiabetes,
        isBigCreatinin,
        volumeContrast,
        speedKF
      )
    );
    setIsLoad(false);
  };

  return (
    <Row style={{marginBottom: 100}}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Вероятность развития контраст индуцированной нефропатии"}
          description={[
            "Метод балльной оценки, учитывающий как клинические состояния, так и лабораторные показатели. R. Mehran et al. была предложена балльная оценка степени риска контраст индуцированной нефропатии перед проведением эндоваскулярных процедур, в последующем модифицированная В. Barrett и P. Parfrey.",
            "К факторам риска авторы отнесли клинические состояния (возраст старше 75 лет, наличие сердечной недостаточности, сахарного диабета, хронической болезни почек, анемии) и характер исследования (объем и способ введения рентгеноконтрастного средства.На основании суммарной оценки баллов определяется категория степени риска: низкая, умеренная,высокая и очень высокая.Вероятность острого снижения функции почек возрастает с увеличением суммарного балла риска.Так, при низкой степени риска частота случаев КИН составляет 7,5 %, а среди пациентов с очень высокой степенью - 57,3 %",
          ]}
        />
      </Col>

      <Col xl={12}>
        <SwitchSelect
          text={"Гипотония – АД менее 90/60 мм рт.ст."}
          setAction={setIsHypotonia}
        />
      </Col>

      <Col xl={12} style={{marginTop: 10}}>
        <SelectedNameValue
          setAction={setSpeedKF}
          name={"Скорость клубочковой фильтрации"}
          width={180}
          values={speedKFVolume}
        />
      </Col>

      <Col xl={12}>
        <SwitchSelect
          text={"Применение внутриаортальной баллонной контрпульсации (ВАБК)"}
          setAction={setIsVABK}
        />
      </Col>

      <Col xl={12} style={{marginTop: 10}}>
        <SelectedNameValue
          setAction={setVolumeContrast}
          name={"Объем введенного контрастного вещества"}
          width={100}
          values={volumeContrastVolume}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Сердечная недостаточность (класс III-IV NYHA)"}
          setAction={setIsNYHA}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect text={"Возраст старше 75 лет"} setAction={setIsOldAge} />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Анемия – Hb < 12 г/дл для женщин, Hb < 13 г/дл для мужчин"}
          setAction={setIsAnemya}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect text={"Сахарный диабет"} setAction={setIsDiabetes} />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Уровень креатинина > 132,6 мкмоль/л (1,5 мг/дл)"}
          setAction={setIsBigCreatinin}
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
export default KIN;
