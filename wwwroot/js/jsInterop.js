window.isNullOrUndefined = (objectToValidate) => {
    return objectToValidate === undefined || objectToValidate === null;
}

window.replaceClass = (id, classToReplace, classToUse) => {
    let elementToUpdate = document.getElementById(id);

    if (window.isNullOrUndefined(elementToUpdate)) {
        console.log('no element to update found');
        return;
    }

    let elementClassListToReplace = elementToUpdate.classList;

    if (window.isNullOrUndefined(elementClassListToReplace)) {
        console.log('no element class list to update found');
        return;
    }

    console.log(`updated element ${id} from class ${classToReplace} with ${classToUse}`)
    elementClassListToReplace.replace(classToReplace, classToUse);
}
