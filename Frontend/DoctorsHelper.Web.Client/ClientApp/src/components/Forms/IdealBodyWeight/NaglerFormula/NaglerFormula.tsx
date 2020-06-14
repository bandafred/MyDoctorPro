import * as React from "react";
import {Row, Col} from "antd";
import styles from "./NaglerFormula.module.css";
import {useState} from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import {NaglerFormulaResponse} from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IResult} from "../../../../common/Interfaces";
import {NaglerFormulaCalculate} from "./Actions/NaglerFormulaCalculate";

const NaglerFormula = () => {
    let heightDefault = 141;

    let def: IResult<NaglerFormulaResponse> = {
        error: undefined,
        result: undefined,
    };

    const [isMan, setIsMan] = useState(false);
    const [height, setHeight] = useState(heightDefault);
    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(await NaglerFormulaCalculate(height, isMan));
        setIsLoad(false);
    };

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <TitleCalculator
                    name={"Формула Наглера"}
                    description={
                        "Формула Наглера для определения идеального основана на показателе роста и пола. Не учитывает тип телосложения и возраст."
                    }
                />
            </Col>

            <Col xl={3} className={styles.genderSelect}>
                <GenderSelect isMan={isMan} setIsMan={setIsMan}/>
            </Col>

            <Col xl={11}>
                <HeightSelect
                    setAction={setHeight}
                    default={heightDefault}
                    min={141}
                    max={350}
                />
            </Col>

            <Col xl={24}>
                <ButtonResult isLoad={isLoad} calcing={calcing}/>
            </Col>

            <Col xl={24}>
                <Result result={result.result?.result} error={result.error}/>
            </Col>
        </Row>
    );
};
export default NaglerFormula;
