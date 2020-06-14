import * as React from "react";
import {Row, Col} from "antd";
import styles from "./MillerFormula.module.css";
import {useState} from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import {MillerFormulaResponse} from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {IResult} from "../../../../common/Interfaces";
import {MillerFormulaCalculate} from "./Actions/MillerFormulaCalculate";


const MillerFormula = () => {
    let heightDefault = 101;

    let def: IResult<MillerFormulaResponse> = {
        error: undefined,
        result: undefined,
    };

    const [isMan, setIsMan] = useState(false);
    const [height, setHeight] = useState(heightDefault);
    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const calcing = async () => {
        setIsLoad(true);
        setResult(await MillerFormulaCalculate(height, isMan));
        setIsLoad(false);
    };

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <TitleCalculator
                    name={"Формула Миллера"}
                    description={
                        "Улучшенная формула Девина появилась в 1983 году. Миллер внес изменения в формулу Девина, так как старая формула не опиралась ни на какие статистические данные и основывалась только на математических методах. Но новая формула также основана на росте."
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
                    min={101}
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
export default MillerFormula;
