
function getGridInfo(gridName, headerName, showData, columnsData, recordsData, isMultiSelect) {

    // show部を変換する。
    var showArray = [];
    showArray.push(new Function('return ' + showData)());

    // ヘッダ部を変換する。
    var columnsArray = convertArray(columnsData);

    // データ部を変換する。
    var recordsArray = convertArray(recordsData);

    var gridConfig = {
        grid1: {
            name: gridName,
            header: headerName,
            show: showArray[0],
            multiSelect: isMultiSelect,
            columns: columnsArray,
            records: recordsArray
        }
    };

    return gridConfig;
}


function convertArray(targetArray) {

    var convertArray = [];
    if (Object.keys(targetArray).length > 0) {
        for (var value in targetArray) {
            var row = targetArray[value];
            convertArray[convertArray.length] = new Function('return ' + row)();
        }
    }

    return convertArray;
}


function setGridColumns(gridName, columns) {
    w2ui[gridName].columns = columns;
}


function setGridRecords(records, gridName) {
    w2ui[gridName].records = records;
    w2ui[gridName].select(-1);
    w2ui[gridName].reload();
}


function setGridColumnsAndRecords(gridName, columns, records) {
    w2ui[gridName].columns = columns;
    w2ui[gridName].records = records;
    w2ui[gridName].select(-1);
    w2ui[gridName].reload();
}


function getGridSelectedColumnValue(gridName, itemIdColumnName) {

    var value = '';
    var selected = w2ui[gridName].getSelection();
    var len = selected.length;
    if (len > 0) {
        for (var i = 0; i < len; i++) {
            if (i > 0) {
                value += ',';
            }

            value += w2ui[gridName].get(selected[i])[itemIdColumnName];
        }
    }

    return value;
}


function getGridColumnValue(gridName, itemIdColumnName, itemId, itemValueColumnName) {

    var mainRecords = w2ui[gridName].records;
    var value = '';
    var len = mainRecords.length;
    for (var i = 0; i < len; i++) {
        if (mainRecords[i][itemIdColumnName] == itemId) {
            value = mainRecords[i][itemValueColumnName];

            // 確定していないグリッドの値が設定されている場合はそちらを優先する。
            var changeRecord = w2ui[gridName].getChanges();
            for (var r in changeRecord) {
                var d = changeRecord[r];
                if (d.recid == mainRecords[i].recid) {
                    var changeValue = changeRecord[r][itemValueColumnName];
                    value = changeValue;
                    break;
                }
            }

            break;
        }
    }

    return value;
}


function setGridItemValue(gridName, itemIdColumnName, itemId, itemValueColumnName, itemValue) {

    // 指定された列の値に合致するレコードIDを取得する。
    var recordId = getGridColumnValue(gridName, itemIdColumnName, itemId, "recid");
    if (recordId.length == 0) {
        recordId = 0;
    }

    // 取得したレコードIDの列に値を設定する。
    w2ui[gridName].get(recordId)[itemValueColumnName] = itemValue;
    w2ui[gridName].refreshCell(recordId, itemValueColumnName);
}


function getDisabled(authority) {
    var disabled = false;
    // 権限が「3:一般」以下の場合、入力不可とする。
    if (authority >= 3) {
        disabled = true;
    }
    return disabled;
}


function getDisabledExceptSuperUser(authority) {
    var disabled = false;
    // 権限が「2:管理者」以下の場合、入力不可とする。
    if (authority >= 2) {
        disabled = true;
    }
    return disabled;
}


function getDisabledReadonlyUserAlone(authority) {
    var disabled = false;
    // 権限が「4:閲覧」以下の場合、入力不可とする。
    if (authority >= 4) {
        disabled = true;
    }
    return disabled;
}

function getChangeValue(beforeValue, changeValue) {
    var ret;
    if (changeValue === undefined) {
        ret = beforeValue;
    } else {
        ret = changeValue;
    }
    return ret;
}
